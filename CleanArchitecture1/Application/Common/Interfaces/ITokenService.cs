using Application.Dto;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces
{
    public interface ITokenService
    {
        string CreateJwtSecurityToken(ApplicationUserDto applicationUserDto,IList<string> userRoles);
        bool validToken(string token);
    }
}
