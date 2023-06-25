using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapp
{
    public class CategoryProfile : Profile
    {

        public CategoryProfile()
        {

            CreateMap<Domain.entity.Member, Dto.MemberDto>().ReverseMap();

        }
  
    }
}
