using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class CategoryProfile : Profile
    {

        public CategoryProfile()
        {

            CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();

        }

    }
}
