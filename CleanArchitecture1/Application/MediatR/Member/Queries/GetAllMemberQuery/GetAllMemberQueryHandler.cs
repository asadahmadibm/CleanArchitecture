using Application.Common.Interfaces;
using Application.Common.Models;

namespace Application.MediatR.Member.Queries.GetAllMemberQuery
{
    public class GetAllMemberQueryHandler : IRequestHandler<GetAllMemberQueryModel, List<MemberDto>>
    {
        private readonly IMapper _mapper;
        private IMemberRepository _memberRepository;
        public GetAllMemberQueryHandler(IMapper mapper, IMemberRepository memberRepository)
        {
            _mapper = mapper;
            _memberRepository = memberRepository;   
        }
        public async Task<List<MemberDto>> Handle(GetAllMemberQueryModel request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<Domain.Entities.Member>, List<MemberDto>>(await _memberRepository.GetAllMembersAsync()); ;
            throw new NotImplementedException();
        }
    }
}
