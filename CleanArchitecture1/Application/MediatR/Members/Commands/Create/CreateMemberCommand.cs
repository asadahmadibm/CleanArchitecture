
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Domain.Entities;
using Domain.Events;
using System.ComponentModel.DataAnnotations;

namespace Application.MediatR.Members.Commands.Create
{
    public class CreateMemberCommand : IRequestWrapper<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
    }
    public class CreateMemberCommandHandler : IRequestHandlerWrapper<CreateMemberCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateMemberCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResult<int>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Member
            {
                Name = request.Name,
                Type = request.Type,
                Address = request.Address,
            };

            entity.AddDomainEvent(new MemberCreatedEvent(entity));

            await _context.Memberss.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(entity.Id);
        }
    }
}
