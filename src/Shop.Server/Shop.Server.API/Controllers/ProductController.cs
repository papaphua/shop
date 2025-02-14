using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Server.API.Core;
using Shop.Server.BLL.Products;
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

    [Authorize(Roles = "1")]
    [HttpPost]
    public async Task<IResult> Create(ProductDto dto)
    {
        var result = await productService.CreateAsync(dto);

        return result.IsSuccess
            ? Results.Ok()
            : result.ToProblemDetails();
    }

    [Authorize(Roles = "1")]
    [HttpDelete("{productId:int}")]
    public async Task<IResult> Remove(int productId)
    {
        var result = await productService.RemoveAsync(productId);

        return result.IsSuccess
            ? Results.Ok()
            : result.ToProblemDetails();
    }

    [Authorize(Roles = "1")]
    [HttpPut("{productId:int}")]
    public async Task<IResult> Update(int productId, ProductDto dto)
    {
        var result = await productService.UpdateAsync(productId, dto);

        return result.IsSuccess
            ? Results.Ok()
            : result.ToProblemDetails();
    }
}