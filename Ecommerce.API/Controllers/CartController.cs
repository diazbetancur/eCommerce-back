using Ecommerce.Application.DTOs.Cart;
using Ecommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetByCustomer(Guid customerId)
    {
        var cart = await _cartService.GetByCustomerIdAsync(customerId);
        return cart == null ? NotFound() : Ok(cart);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCartDto dto)
    {
        var created = await _cartService.CreateAsync(dto);
        return Ok(created);
    }

    [HttpPost("{cartId}/items")]
    public async Task<IActionResult> AddItem(Guid cartId, CreateCartItemDto dto)
    {
        var added = await _cartService.AddItemAsync(cartId, dto);
        return added ? Ok() : NotFound();
    }

    [HttpDelete("items/{itemId}")]
    public async Task<IActionResult> RemoveItem(Guid itemId)
    {
        var removed = await _cartService.RemoveItemAsync(itemId);
        return removed ? NoContent() : NotFound();
    }

    [HttpDelete("{cartId}/clear")]
    public async Task<IActionResult> ClearCart(Guid cartId)
    {
        await _cartService.ClearCartAsync(cartId);
        return NoContent();
    }
}