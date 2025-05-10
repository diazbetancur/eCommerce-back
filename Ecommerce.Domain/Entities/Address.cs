namespace Ecommerce.Domain.Entities;

public class Address : EntityBase<Guid>
{
    public Guid CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Country { get; set; } = "Colombia";
}