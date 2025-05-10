namespace Ecommerce.Application.DTOs.Order;

public class OrderDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = "Pending";
    public decimal Total { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}