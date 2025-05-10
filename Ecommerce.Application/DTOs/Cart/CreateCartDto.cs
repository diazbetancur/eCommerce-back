namespace Ecommerce.Application.DTOs.Cart;

public class CreateCartDto
{
    public Guid CustomerId { get; set; }
    public List<CreateCartItemDto> Items { get; set; } = new();
}