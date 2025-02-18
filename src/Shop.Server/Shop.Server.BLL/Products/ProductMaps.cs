using AutoMapper;
using Shop.Server.DAL.Products;
using Shop.Server.DAL.ProductTypes;
using Shop.Shared.Products;
using Shop.Shared.ProductTypes;

namespace Shop.Server.BLL.Products;

public sealed class ProductMaps : Profile
{
    public ProductMaps()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<ProductType, ProductTypeDto>();
    }
}