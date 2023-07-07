using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Security;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.Security;
using System.Threading;

namespace Application.Common.Behaviours;

public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IUser _user;
    private readonly IIdentityService _identityService;
    private IHttpContextAccessor _httpContextAccessor;

    public AuthorizationBehaviour(
        IHttpContextAccessor httpContextAccessor,
        IUser user,
        IIdentityService identityService)
    {
        _httpContextAccessor = httpContextAccessor;
        _user = user;
        _identityService = identityService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

        if (authorizeAttributes.Any())
        {
            // Must be authenticated user
            if (_user.Id == null)
            {
                throw new UnauthorizedAccessException();
            }

            // Role-based authorization
            var authorizeAttributesWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));

            if (authorizeAttributesWithRoles.Any())
            {
                var authorized = false;

                foreach (var roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
                {
                    foreach (var role in roles)
                    {
                        var isInRole = await _identityService.IsInRoleAsync(_user.Id, role.Trim());
                        if (isInRole)
                        {
                            authorized = true;
                            break;
                        }
                    }
                }

                // Must be a member of at least one role in roles
                if (!authorized)
                {
                    throw new ForbiddenAccessException();
                }
            }

            // Policy-based authorization
            var authorizeAttributesWithPolicies = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Policy));
            if (authorizeAttributesWithPolicies.Any())
            {
                foreach (var policy in authorizeAttributesWithPolicies.Select(a => a.Policy))
                {
                    var authorized = await _identityService.AuthorizeAsync(_user.Id, policy);

                    if (!authorized)
                    {
                        throw new ForbiddenAccessException();
                    }
                }
            }

            //Permission Based by asad 
            var authorizeAttributesWithPermissions = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Permission));
            if (authorizeAttributesWithPermissions.Any())
            {
                if (_httpContextAccessor == null)
                {
                    throw new NullReferenceException("no");
                }
                if (_httpContextAccessor.HttpContext.User == null)
                {
                    throw new CbiForbbidenException($"User Not Defined");
                }

                var per = _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == AppCustomeClaims.Permission).Select(a => a.Value).FirstOrDefault();
                if (string.IsNullOrWhiteSpace(per))
                {
                    throw new CbiForbbidenException($"User Not Any Permission");
                }

                var permissions = per.Split(",");
                bool hasAccess = false;
                foreach (var _permission in authorizeAttributesWithPermissions.Select(a => a.Permission))
                {
                    hasAccess = permissions.Any(a => {
                        var value = a.ToLower();
                        return value == AppPermissions.SysAdmin.Key.ToLower()
                        || value == _permission.ToLower();
                    });

                    if (hasAccess)
                    {
                        return await next();
                    }
                }

                if (!hasAccess)
                    throw new CbiForbbidenException($"Invalid access to {permissions}");
            }
        }

        // User is authorized / authorization not required
        return await next();
    }

}
