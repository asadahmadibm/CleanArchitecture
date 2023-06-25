using Application.IRepository;
using Application.IService;
using Domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        List<Member> IMemberService.GetAllMembers()
        {
            return _memberRepository.GetAllMembers();
        }
    }
}
