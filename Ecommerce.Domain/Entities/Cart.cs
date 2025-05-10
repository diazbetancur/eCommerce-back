namespace Ecommerce.Domain.Entities;

public class Cart : EntityBase<Guid>
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
}