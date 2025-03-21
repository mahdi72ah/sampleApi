using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using sampleApi.Application.CQRS.ProductCommandQuery.Query;
using sampleApi.Core.Entities;
using sampleApi.Infrastructure.Dtos;

namespace sampleApi.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // نقشه‌برداری ساده از Product به ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CombinedInfo, opt => opt.MapFrom(src => $"{src.ProductName} {src.Price}"))
                .ForMember(dest => dest.PriceWithComma, opt => opt.MapFrom(src => String.Format("{0:N0}", src.Price)))
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // در صورت نیاز به نادیده گرفتن فیلدها
                .ReverseMap(); // نقشه‌برداری برعکس از ProductDto به Product

            CreateMap<Product, GetProductQueryResponse>()
                .ForMember(dest => dest.CombinedInfo, opt => opt.MapFrom(src => $"{src.ProductName} {src.Price}"))
                .ForMember(dest => dest.PriceWithComma, opt => opt.MapFrom(src => string.Format("{0:N0}", src.Price)))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
