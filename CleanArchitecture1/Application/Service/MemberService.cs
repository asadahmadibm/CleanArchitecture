using Application.Dto;
using Application.IRepository;
using Application.IService;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }
        public async Task<List<MemberDto>> GetAllMembersasync()
        {
            return _mapper.Map<List<Member>,List<MemberDto>> (await _memberRepository.GetAllMembersAsync());
        }
    }
}
