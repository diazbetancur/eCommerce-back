namespace Ecommerce.Domain.Entities;

public class Brand : EntityBase<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string? LogoUrl { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}