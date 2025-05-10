namespace Ecommerce.Domain.Entities;

public class ProductReview : EntityBase<Guid>
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int Rating { get; set; } // 1 a 5 estrellas
    public string? Comment { get; set; }
    public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
}