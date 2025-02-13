using AutoMapper;
using Shop.Server.DAL.Products;
using Shop.Shared.Products;

namespace Shop.Server.BLL.Products;

public sealed class ProductMaps : Profile
{
    public ProductMaps()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}