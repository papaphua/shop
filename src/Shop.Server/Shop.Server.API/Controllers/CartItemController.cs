using Microsoft.AspNetCore.Mvc;
using Shop.Server.API.Core;
using Shop.Shared.CartItems;
using Shop.Shared.Core.Pagination;

namespace Shop.Server.API.Controllers;

[Route("api/cart-item")]
public sealed class CartItemController(ICartItemService cartItemService) : ApiController
{
    [HttpGet]
    public async Task<IResult> Get([FromQuery] PagingQuery? query)
    {
        var result = await cartItemService.GetAsync(query, UserId);

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : result.ToProblemDetails();
    }

    [HttpPost("{productId:int}")]
    public async Task<IResult> Add(int productId)
    {
        var result = await cartItemService.AddAsync(UserId, productId);

        return result.IsSuccess
            ? Results.Ok()
            : result.ToProblemDetails();
    }

    [HttpDelete("{cartItemId:int}")]
    public async Task<IResult> Remove(int cartItemId)
    {
        var result = await cartItemService.RemoveAsync(UserId, cartItemId);

        return result.IsSuccess
            ? Results.Ok()
            : result.ToProblemDetails();
    }

    [HttpPut("{cartItemId:int}")]
    public async Task<IResult> SetQuantity(int cartItemId, int quantity)
    {
        var result = await cartItemService.SetQuantityAsync(UserId, cartItemId, quantity);

        return result.IsSuccess
            ? Results.Ok()
            : result.ToProblemDetails();
    }
}