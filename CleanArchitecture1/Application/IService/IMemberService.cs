using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Domain.entity;

namespace Application.IService
{
    public interface IMemberService
    {
        Task<List<MemberDto>> GetAllMembersasync();
    }
}
