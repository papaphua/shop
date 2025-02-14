using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Shop.Server.BLL.CartItems;
using Shop.Shared.CartItems;
using Shop.Shared.Core.Pagination;

namespace Shop.Client.Customer.Pages;

[Authorize]
public sealed partial class CartPage : ComponentBase
{
    private const int PageSize = 6;
    private PagedList<CartItemDto> _list = new();
    [Inject] public required ICartItemService CartItemService { get; set; }
    [Inject] public required IHttpContextAccessor HttpContextAccessor { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await HandleLoadPageAsync(1);
    }

    private async Task HandleLoadPageAsync(int pageNumber)
    {
        var userIdString = HttpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var success = int.TryParse(userIdString, out var userIdInt);

        if (!success)
        {
            NavigationManager.NavigateTo("/logout");
        }

        var query = new PagingQuery(pageNumber, PageSize);
        var result = await CartItemService.GetAsync(query, userIdInt);
        if (result.IsSuccess) _list = result.Value!;
    }

    private async Task HandleSetQuantityAsync(int cartItemId, int quantity)
    {
        var userIdString = HttpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var success = int.TryParse(userIdString, out var userIdInt);

        if (!success)
        {
            NavigationManager.NavigateTo("/logout");
        }

        var res = await CartItemService.SetQuantityAsync(userIdInt, cartItemId, quantity);
        
        if (res.IsSuccess)
        {
            await HandleLoadPageAsync(_list.Metadata.PageNumber);
        }
    }

    private async Task HandleDeleteAsync(int cartItemId)
    {
        var userIdString = HttpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var success = int.TryParse(userIdString, out var userIdInt);

        if (!success)
        {
            NavigationManager.NavigateTo("/logout");
        }
        
        var res = await CartItemService.RemoveAsync(userIdInt, cartItemId);

        if (res.IsSuccess)
        {
            await HandleLoadPageAsync(_list.Metadata.PageNumber);
        }
    }
}