using AutoMapper;

namespace DefinitiveChallenge.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, Models.ProductDto>();
            CreateMap<Models.ProductCreationDto, Entities.Product>();
            CreateMap<Models.ProductUpdateDto, Entities.Product>();
            CreateMap<Entities.Product, Models.ProductUpdateDto>();
        }
    }
}
