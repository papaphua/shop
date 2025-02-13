using Shop.Shared.Core.Results;

namespace Shop.Server.BLL.Products;

public static class ProductErrors
{
    public static readonly Error NotFound = Error.NotFound(
        "Product.NotFound", "Product not found.");
}