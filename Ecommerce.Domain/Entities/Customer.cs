using System.Net;

namespace Ecommerce.Domain.Entities;

public class Customer : EntityBase<Guid>
{
    public string FirebaseUid { get; set; } = string.Empty; // clave para enlazar con Firebase Auth
    public string? FullName { get; set; }
    public string? Email { get; set; }

    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}