using Shop.Server.DAL.CartItems;
using Shop.Server.DAL.Core;

namespace Shop.Server.DAL.Users;

public sealed class User : Entity<int>
{
    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public Role Role { get; set; }

    public ICollection<CartItem> CartItems { get; set; }
}