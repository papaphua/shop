using AutoMapper;
using Shop.Server.BLL.Products;
using Shop.Server.DAL.CartItems;
using Shop.Server.DAL.Core;
using Shop.Server.DAL.Products;
using Shop.Shared.CartItems;
using Shop.Shared.Core.Pagination;
using Shop.Shared.Core.Results;

namespace Shop.Server.BLL.CartItems;

public sealed class CartItemService(
    ICartItemRepository cartItemRepository,
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : ICartItemService
{
    public async Task<Result<PagedList<CartItemDto>>> GetAsync(PagingQuery? query, int userId)
    {
        var cartItems = await cartItemRepository.GetAsync(query, userId);
        var dtos = cartItems.Items.Select(mapper.Map<CartItemDto>);
        return dtos.AsPagedList(cartItems.Metadata);
    }

    public async Task<Result> AddAsync(int userId, int productId)
    {
        var product = await productRepository.GetByIdAsync(productId);

        if (product == null)
            return ProductErrors.NotFound;

        var existingCartItem = await cartItemRepository.GetByIdsAsync(userId, productId);

        if (existingCartItem != null)
            existingCartItem.Quantity++;
        else
            await cartItemRepository.AddAsync(new CartItem
            {
                UserId = userId,
                ProductId = productId,
                Quantity = 1
            });

        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> RemoveAsync(int userId, int cartItemId)
    {
        var cartItem = await cartItemRepository.GetByIdAsync(cartItemId);

        if (cartItem == null)
            return CartItemErrors.NotFound;

        cartItemRepository.Remove(cartItem);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> SetQuantityAsync(int userId, int cartItemId, int quantity)
    {
        var cartItem = await cartItemRepository.GetByIdAsync(cartItemId);

        if (cartItem == null)
            return CartItemErrors.NotFound;

        if (quantity < 1)
            return CartItemErrors.InvalidQuantity;

        cartItem.Quantity = quantity;

        cartItemRepository.Update(cartItem);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}