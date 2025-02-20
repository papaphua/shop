﻿using Shop.Server.DAL.CartItems;
using Shop.Server.DAL.Core;
using Shop.Server.DAL.ProductTypes;

namespace Shop.Server.DAL.Products;

public sealed class Product : Entity<int>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public byte[] ImageData { get; set; }

    public ICollection<CartItem> CartItems { get; set; }

    public ProductType ProductType { get; set; }

    public int ProductTypeId { get; set; }
}