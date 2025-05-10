namespace Ecommerce.Domain.Entities;

public class Category : EntityBase<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}