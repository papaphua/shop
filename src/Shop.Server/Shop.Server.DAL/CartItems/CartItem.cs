using Shop.Server.DAL.Core;
using Shop.Server.DAL.Products;
using Shop.Server.DAL.Users;

namespace Shop.Server.DAL.CartItems;

public sealed class CartItem : Entity<int>
{
    public int UserId { get; set; }

    public User User { get; set; }

    public int ProductId { get; set; }

    public Product Product { get; set; }

    public int Quantity { get; set; }
}