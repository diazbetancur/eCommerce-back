namespace Ecommerce.Application.DTOs.Cart;

public class CartDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public List<CartItemDto> Items { get; set; } = new();
}