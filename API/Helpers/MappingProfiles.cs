﻿using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(p => p.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(p => p.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<CostumerBasketDTO, CostumerBasket>();
            CreateMap<BasketItemsDTO, BasketItems>();

        }
    }
}
