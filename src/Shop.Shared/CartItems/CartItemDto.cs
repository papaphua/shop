using Shop.Shared.Products;

namespace Shop.Shared.CartItems;

public sealed class CartItemDto
{
    public int Id { get; set; }

    public ProductDto Product { get; set; }
}