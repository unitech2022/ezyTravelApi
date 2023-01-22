using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TouristApi.Dtos;
using TouristApi.Models;

namespace TouristApi.Profils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // CreateMap<UserForRegister, User>();
            // CreateMap<User, UserDetailResponse>();

            // CreateMap<UpdateCategoryDto, Category>();
            // CreateMap<UpdateFieldDto, Field>();

            // CreateMap<UpdateProductDto, Product>();
            CreateMap<UpdateContinent, Continent>();
             CreateMap<UpdateCountry, Country>();
              CreateMap<UpdateCity, City>();
            CreateMap<UpdatePlace,  Place>();
            // CreateMap<UpdateOrderItemOptionDto, OrderItemOption>();
            // CreateMap<UpdateAddressDto, Address>();
            // CreateMap<UpdateAlertDto, Alert>();
            // CreateMap<UpdateAppConfigDto, AppConfig>();

        }
    }
}