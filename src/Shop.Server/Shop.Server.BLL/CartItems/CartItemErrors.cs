using Shop.Server.BLL.Core.Results;

namespace Shop.Server.BLL.CartItems;

public static class CartItemErrors
{
    public static readonly Error NotFound = Error.NotFound(
        "CartItem.NotFound", "Cart item not found.");

    public static readonly Error InvalidQuantity = Error.Validation(
        "CartItem.InvalidQuantity", "Quantity must be at least 1.");
}