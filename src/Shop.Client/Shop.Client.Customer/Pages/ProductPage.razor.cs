using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Shop.Server.BLL.CartItems;
using Shop.Server.BLL.Products;
using Shop.Shared.Core.Pagination;
using Shop.Shared.Products;

namespace Shop.Client.Customer.Pages;

[Authorize]
public sealed partial class ProductPage : ComponentBase
{
    private const int PageSize = 6;
    private PagedList<ProductDto> _list = new();
    [Inject] public required IProductService ProductService { get; set; }
    [Inject] public required ICartItemService CartItemService { get; set; }
    [Inject] public required IHttpContextAccessor HttpContextAccessor { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await HandleLoadPageAsync(1);
    }

    private async Task HandleLoadPageAsync(int pageNumber)
    {
        var query = new PagingQuery(pageNumber, PageSize);
        var result = await ProductService.GetAsync(query);
        if (result.IsSuccess) _list = result.Value!;
    }

    private async Task HandleAddToCartAsync(int productId)
    {
        var userIdString = HttpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var success = int.TryParse(userIdString, out var userIdInt);

        if (!success)
        {
            NavigationManager.NavigateTo("/logout");
        }
        
        await CartItemService.AddAsync(userIdInt, productId);
    }
}