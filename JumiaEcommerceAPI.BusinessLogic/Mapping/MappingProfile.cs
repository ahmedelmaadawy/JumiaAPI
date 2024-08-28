using AutoMapper;
using JumiaEcommeceAPI.DataAccess.Entities;
using JumiaEcommerceAPI.BusinessLogic.DTOs;

namespace JumiaEcommerceAPI.BusinessLogic.Mapping
{
    public class MappingProfile : Profile
    {
        //configration for automapper 
        public MappingProfile()
        {
            CreateMap<ProductToAddDTO, Product>();
            CreateMap<Product, ProductToReadDTO>().ForMember("CategoryName", (opt) => { opt.MapFrom(p => p.Category.Name); });
        }
    }
}
