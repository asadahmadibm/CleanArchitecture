using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
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
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public DeleteMemberCommandHandler(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResult<int>> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            
            var entity = await _memberRepository.GetAsync(request.Id,cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Member), request.Id.ToString());
            }

            await _memberRepository.DeleteAsynv(entity, cancellationToken);

            return ServiceResult.Success(entity.Id);
        }
    }
}
