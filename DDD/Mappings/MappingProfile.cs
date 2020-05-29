using System;
using AutoMapper;
using Core.Models;
using WebApi.DTO;

namespace WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.GetPrice()));
        }
    }
}
