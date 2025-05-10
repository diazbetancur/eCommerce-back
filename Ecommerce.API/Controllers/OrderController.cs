using Ecommerce.Application.DTOs.Order;
using Ecommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetByCustomer(Guid customerId)
    {
        var orders = await _orderService.GetByCustomerIdAsync(customerId);
        return Ok(orders);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderDto dto)
    {
        var order = await _orderService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetByCustomer), new { customerId = dto.CustomerId }, order);
    }
}