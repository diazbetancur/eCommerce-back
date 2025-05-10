namespace Ecommerce.Application.DTOs.Category;

public class CreateCategoryDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? Slug { get; set; }
}