﻿using Microsoft.AspNetCore.Mvc;
using Shop.Server.API.Core;
using Shop.Shared.Core.Pagination;
using Shop.Shared.Products;

namespace Shop.Server.API.Controllers;

[Route("api/product")]
public sealed class ProductController(IProductService productService) : ApiController
{
    [HttpGet]
    public async Task<IResult> Get([FromQuery] PagingQuery? query)
    {
        var result = await productService.GetAsync(query);

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : result.ToProblemDetails();
    }

    [HttpPost]
    public async Task<IResult> Create(ProductDto dto)
    {
        var result = await productService.CreateAsync(dto);

        return result.IsSuccess
            ? Results.Ok()
            : result.ToProblemDetails();
    }

    [HttpDelete("{productId:int}")]
    public async Task<IResult> Remove(int productId)
    {
        var result = await productService.RemoveAsync(productId);

        return result.IsSuccess
            ? Results.Ok()
            : result.ToProblemDetails();
    }

    [HttpPut("{productId:int}")]
    public async Task<IResult> Update(int productId, ProductDto dto)
    {
        var result = await productService.UpdateAsync(productId, dto);

        return result.IsSuccess
            ? Results.Ok()
            : result.ToProblemDetails();
    }
}