using Application.Dto;
using Domain.entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Member.GetAllMemberQuery
{
    public class GetAllMemberQueryModel : IRequest<List<MemberDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
    }
}
