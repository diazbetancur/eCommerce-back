using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities;

public class Product : EntityBase<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public string Sku { get; set; } = string.Empty;
    public int Stock { get; set; }
    public bool IsActive { get; set; } = true;
    public string? ImageUrl { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}