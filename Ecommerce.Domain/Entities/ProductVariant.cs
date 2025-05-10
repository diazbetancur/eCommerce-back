namespace Ecommerce.Domain.Entities;

public class ProductVariant : EntityBase<Guid>
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public string Name { get; set; } = string.Empty; // Ej: "Color"
    public string Value { get; set; } = string.Empty; // Ej: "Rojo"
    public int Stock { get; set; }
}