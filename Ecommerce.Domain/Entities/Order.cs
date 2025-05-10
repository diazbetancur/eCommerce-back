namespace Ecommerce.Domain.Entities;

public class Order : EntityBase<Guid>
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Pending";

    public decimal Total { get; set; }

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}