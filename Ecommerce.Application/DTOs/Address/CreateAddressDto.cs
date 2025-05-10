namespace Ecommerce.Application.DTOs.Address;

public class CreateAddressDto
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Country { get; set; } = "";
    public Guid CustomerId { get; set; }
}