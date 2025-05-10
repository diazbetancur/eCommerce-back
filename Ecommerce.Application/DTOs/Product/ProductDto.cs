namespace Ecommerce.Application.DTOs.Product;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public string Sku { get; set; } = string.Empty;
    public int Stock { get; set; }
    public string? ImageUrl { get; set; }
    public Guid CategoryId { get; set; }
}