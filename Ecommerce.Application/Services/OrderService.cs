using Ecommerce.Application.DTOs.Order;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services;

public class OrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<OrderDto>> GetByCustomerIdAsync(Guid customerId)
    {
        var orders = await _unitOfWork.Orders.FindAsync(o => o.CustomerId == customerId);

        var result = new List<OrderDto>();

        foreach (var order in orders)
        {
            var items = await _unitOfWork.OrderItems.FindAsync(i => i.OrderId == order.Id);
            result.Add(new OrderDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                Total = order.Total,
                Items = items.Select(i => new OrderItemDto
                {
                    ProductId = i.ProductId,
                    ProductName = i.Product.Name,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            });
        }

        return result;
    }

    public async Task<OrderDto> CreateAsync(CreateOrderDto dto)
    {
        var cart = await _unitOfWork.Carts.GetByIdAsync(dto.CartId);
        if (cart == null) throw new Exception("Carrito no encontrado.");

        var items = await _unitOfWork.CartItems.FindAsync(i => i.CartId == dto.CartId);
        if (!items.Any()) throw new Exception("El carrito está vacío.");

        var total = items.Sum(i => i.UnitPrice * i.Quantity);

        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = dto.CustomerId,
            OrderDate = DateTime.UtcNow,
            Status = "Pending",
            Total = total
        };

        await _unitOfWork.Orders.AddAsync(order);

        foreach (var item in items)
        {
            var orderItem = new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            };
            await _unitOfWork.OrderItems.AddAsync(orderItem);
        }

        await _unitOfWork.CompleteAsync();

        // Limpiar carrito
        foreach (var item in items)
            await _unitOfWork.CartItems.DeleteAsync(item);

        await _unitOfWork.CompleteAsync();

        return new OrderDto
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            OrderDate = order.OrderDate,
            Status = order.Status,
            Total = order.Total,
            Items = items.Select(i => new OrderItemDto
            {
                ProductId = i.ProductId,
                ProductName = i.Product.Name,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        };
    }
}