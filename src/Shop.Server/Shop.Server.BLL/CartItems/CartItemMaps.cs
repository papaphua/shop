using AutoMapper;
using Shop.Server.DAL.CartItems;
using Shop.Shared.CartItems;

namespace Shop.Server.BLL.CartItems;

public sealed class CartItemMaps : Profile
{
    public CartItemMaps()
    {
        CreateMap<CartItem, CartItemDto>()
            .ForMember(dest => dest.Product, opt =>
                opt.MapFrom(src => src.Product));
    }
}