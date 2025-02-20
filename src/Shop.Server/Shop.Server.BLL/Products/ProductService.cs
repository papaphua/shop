﻿using AutoMapper;
using Shop.Server.BLL.Core.Results;
using Shop.Server.DAL.Core;
using Shop.Server.DAL.Products;
using Shop.Server.DAL.ProductTypes;
using Shop.Shared.Core.Pagination;
using Shop.Shared.Products;
using Shop.Shared.ProductTypes;

namespace Shop.Server.BLL.Products;

public sealed class ProductService(
    IProductRepository productRepository,
    IProductTypeRepository productTypeRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IProductService
{
    public async Task<Result<ProductDto>> GetByIdAsync(int id)
    {
        return mapper.Map<ProductDto>(await productRepository.GetByIdAsync(id));
    }

    public async Task<Result<PagedList<ProductDto>>> GetAsync(PagingQuery? query, string? productType = null)
    {
        var products = await productRepository.GetAsync(query, productType);
        var dtos = products.Items.Select(mapper.Map<ProductDto>);
        return dtos.AsPagedList(products.Metadata);
    }

    public async Task<Result> CreateAsync(ProductDto dto)
    {
        var product = mapper.Map<Product>(dto);

        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> RemoveAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);

        if (product == null)
            return ProductErrors.NotFound;

        productRepository.Remove(product);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> UpdateAsync(int id, ProductDto dto)
    {
        var product = await productRepository.GetByIdAsync(id);

        if (product == null)
            return ProductErrors.NotFound;

        mapper.Map(dto, product);

        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result<List<ProductTypeDto>>> GetProductTypesAsync()
    {
        var types = await productTypeRepository.GetAllAsync();
        return types.Select(mapper.Map<ProductTypeDto>)
            .ToList();
    }
}