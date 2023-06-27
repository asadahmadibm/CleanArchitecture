using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class CategoryProfile : Profile
    {

        public CategoryProfile()
        {

            CreateMap<Member, MemberDto>().ReverseMap();

        }

    }
}
