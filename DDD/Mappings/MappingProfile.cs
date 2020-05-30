using System;
using AutoMapper;
using Core.Models;
using Core.Models.Responses;
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

            CreateMap<RentResponse, RentResponseDto>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.MovieRental.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.MovieRental.EndDate))
                .ForMember(dest => dest.MovieStream, opt => opt.MapFrom(src => src.MovieStream));

            CreateMap<PurchaseResponse, PurchaseResponseDto>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.MoviePurchase.Date))
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.MoviePurchase.Movie.Name))
                .ForMember(dest => dest.MovieStreamWithDownload, opt => opt.MapFrom(src => src.MovieStreamWithDownload));
        }
    }
}
