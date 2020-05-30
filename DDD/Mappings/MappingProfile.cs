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

            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.FullName.LastName))
                .ForMember(dest => dest.CreditCardValidity, opt => opt.MapFrom(src => src.CreditCard.IsValid))
                .ForMember(dest => dest.CreditCardLastDigits, opt =>
                {
                    opt.MapFrom(src => src.CreditCard.Value.Substring(src.CreditCard.Value.Length - 4));
                });
        }
    }
}
