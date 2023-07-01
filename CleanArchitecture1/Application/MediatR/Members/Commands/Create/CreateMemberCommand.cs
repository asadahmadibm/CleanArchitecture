
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Application.Dto;
using Domain.Entities;
using Domain.Events;
using System.ComponentModel.DataAnnotations;

namespace Application.MediatR.Members.Commands.Create
{

    public class CreateMemberCommand : IRequestWrapper<int>
    {
        public MemberDto memberDto  { get; set; }
      
    }
    public class CreateMemberCommandHandler : IRequestHandlerWrapper<CreateMemberCommand, int>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        public CreateMemberCommandHandler(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResult<int>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Member>(request.memberDto);

            entity.AddDomainEvent(new MemberCreatedEvent(entity));

            await _memberRepository.AddAsync(entity);

            return ServiceResult.Success(entity.Id);
        }
    }
}
