using Application.Dto;
using Application.IService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Member.GetAllMemberQuery
{
    public class GetAllMemberQueryHandler : IRequestHandler<GetAllMemberQueryModel, List<MemberDto>>
    {
        private readonly IMemberService _memberService;
        public GetAllMemberQueryHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<List<MemberDto>> Handle(GetAllMemberQueryModel request, CancellationToken cancellationToken)
        {
            return await _memberService.GetAllMembersasync();
            throw new NotImplementedException();
        }
    }
}
