namespace Shop.Shared.Products;

public sealed class ProductDto()
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public byte[] ImageData { get; set; }
}