using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using AutoMapper.Execution;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Members.Commands.Delete
{

    public class DeleteMemberCommand : IRequestWrapper<int>
    {
        public int Id { get; set; }
    }

    public class DeleteMemberCommandHandler : IRequestHandlerWrapper<DeleteMemberCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteMemberCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResult<int>> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Memberss
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(City), request.Id.ToString());
            }

            _context.Memberss.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(entity.Id);
        }
    }
}
