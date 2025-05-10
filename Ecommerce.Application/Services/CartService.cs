using Ecommerce.Application.DTOs.Cart;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services;

public class CartService
{
    private readonly IUnitOfWork _unitOfWork;

    public CartService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CartDto?> GetByCustomerIdAsync(Guid customerId)
    {
        var cart = (await _unitOfWork.Carts.FindAsync(c => c.CustomerId == customerId)).FirstOrDefault();
        if (cart == null) return null;

        var items = await _unitOfWork.CartItems.FindAsync(i => i.CartId == cart.Id);

        return new CartDto
        {
            Id = cart.Id,
            CustomerId = cart.CustomerId,
            Items = items.Select(i => new CartItemDto
            {
                Id = i.Id,
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        };
    }

    public async Task<CartDto> CreateAsync(CreateCartDto dto)
    {
        var cart = new Cart
        {
            Id = Guid.NewGuid(),
            CustomerId = dto.CustomerId,
        };

        await _unitOfWork.Carts.AddAsync(cart);

        foreach (var item in dto.Items)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
            if (product == null) throw new Exception("Producto no encontrado");

            var cartItem = new CartItem
            {
                Id = Guid.NewGuid(),
                CartId = cart.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = product.Price
            };

            await _unitOfWork.CartItems.AddAsync(cartItem);
        }

        await _unitOfWork.CompleteAsync();

        return await GetByCustomerIdAsync(dto.CustomerId) ?? throw new Exception("Error creando carrito");
    }

    public async Task<bool> AddItemAsync(Guid cartId, CreateCartItemDto itemDto)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(itemDto.ProductId);
        if (product == null) return false;

        var cartItem = new CartItem
        {
            Id = Guid.NewGuid(),
            CartId = cartId,
            ProductId = itemDto.ProductId,
            Quantity = itemDto.Quantity,
            UnitPrice = product.Price
        };

        await _unitOfWork.CartItems.AddAsync(cartItem);
        await _unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> RemoveItemAsync(Guid itemId)
    {
        var item = await _unitOfWork.CartItems.GetByIdAsync(itemId);
        if (item == null) return false;

        await _unitOfWork.CartItems.DeleteAsync(item);
        await _unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> ClearCartAsync(Guid cartId)
    {
        var items = await _unitOfWork.CartItems.FindAsync(i => i.CartId == cartId);
        foreach (var item in items)
        {
            await _unitOfWork.CartItems.DeleteAsync(item);
        }

        await _unitOfWork.CompleteAsync();
        return true;
    }
}