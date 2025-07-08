using Ecommerce.Shared.Enums;

namespace Ecommerce.Domain.Entities;

public class User : EntityBase<Guid>
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserRole Role { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<UserAuthProvider> AuthProviders { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; } // ✅ Múltiples roles
    public virtual ICollection<UserPermission> UserPermissions { get; set; }
}
