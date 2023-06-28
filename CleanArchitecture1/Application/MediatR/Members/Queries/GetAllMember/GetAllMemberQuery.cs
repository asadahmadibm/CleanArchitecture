using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using System.Collections.Generic;

namespace Application.MediatR.Member.Queries.GetAllMemberQuery
{
    public class GetAllMemberQuery : IRequestWrapper<List<MemberDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
    }
    public class GetAllMemberQueryHandler : IRequestHandlerWrapper<GetAllMemberQuery, List<MemberDto>>
    {
        private readonly IMapper _mapper;
        private IMemberRepository _memberRepository;
        public GetAllMemberQueryHandler(IMapper mapper, IMemberRepository memberRepository)
        {
            _mapper = mapper;
            _memberRepository = memberRepository;   
        }
        public async Task<ServiceResult<List<MemberDto>>> Handle(GetAllMemberQuery request, CancellationToken cancellationToken)
        {
            var list = _mapper.Map<List<Domain.Entities.Member>, List<MemberDto>>(await _memberRepository.GetAllMembersAsync()); ;
            return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<MemberDto>>(ServiceError.NotFound);
        }
    }
}
