﻿using Shop.Server.BLL.Core.Results;
using Shop.Shared.Core.Pagination;
using Shop.Shared.Products;
using ProductTypeDto = Shop.Shared.ProductTypes.ProductTypeDto;

namespace Shop.Server.BLL.Products;

public interface IProductService
{
    Task<Result<ProductDto>> GetByIdAsync(int id);

    Task<Result<PagedList<ProductDto>>> GetAsync(PagingQuery? query, string? productType = null);

    Task<Result> CreateAsync(ProductDto dto);

    Task<Result> RemoveAsync(int id);

    Task<Result> UpdateAsync(int id, ProductDto dto);

    Task<Result<List<ProductTypeDto>>> GetProductTypesAsync();
}