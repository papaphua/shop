using Shop.Shared.Core;

namespace Shop.Shared.ProductTypes;

public sealed class ProductTypeDto : IDropDownOption
{
    public int Id { get; set; }
    public string Name { get; set; }
}