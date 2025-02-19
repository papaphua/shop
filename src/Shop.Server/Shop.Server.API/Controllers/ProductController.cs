using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Server.API.Core;
using Shop.Server.BLL.Products;
using Shop.Server.DAL.Users;
using Shop.Shared.Core.Pagination;
using Shop.Shared.Products;

namespace Shop.Server.API.Controllers;

[Route("api/product")]
public sealed class ProductController(IProductService productService) : ApiController
{
    [Authorize]
    [HttpGet]
    public async Task<IResult> Get([FromQuery] PagingQuery? query, [FromQuery] string? productType)
    {
        var result = await productService.GetAsync(query, productType);

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : result.ToProblemDetails();
    }
    
    [Authorize]
    [HttpGet("types")]
    public async Task<IResult> GetProductTypes()
    {
        var result = await productService.GetProductTypesAsync();

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : result.ToProblemDetails();
    }
    
    [Authorize(Roles = nameof(Role.Admin))]
    [HttpGet("{id:int}")]
    public async Task<IResult> GetById(int id)
    {
        var result = await productService.GetByIdAsync(id);

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : result.ToProblemDetails();
    }

    [Authorize(Roles = nameof(Role.Admin))]
    [HttpPost]
    public async Task<IResult> Create(ProductDto dto)
    {
        var result = await productService.CreateAsync(dto);

        return result.IsSuccess
            ? Results.Ok()
            : result.ToProblemDetails();
    }

    [Authorize(Roles = nameof(Role.Admin))]
    [HttpDelete("{productId:int}")]
    public async Task<IResult> Remove(int productId)
    {
        var result = await productService.RemoveAsync(productId);

        return result.IsSuccess
            ? Results.Ok()
            : result.ToProblemDetails();
    }

    [Authorize(Roles = nameof(Role.Admin))]
    [HttpPut("{productId:int}")]
    public async Task<IResult> Update(int productId, ProductDto dto)
    {
        var result = await productService.UpdateAsync(productId, dto);

        return result.IsSuccess
            ? Results.Ok()
            : result.ToProblemDetails();
    }
}