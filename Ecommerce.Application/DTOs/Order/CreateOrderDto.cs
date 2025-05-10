namespace Ecommerce.Application.DTOs.Order;

public class CreateOrderDto
{
    public Guid CustomerId { get; set; }
    public Guid CartId { get; set; }
}