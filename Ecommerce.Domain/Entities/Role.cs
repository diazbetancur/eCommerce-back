
using Ecommerce.Shared.Enums;

namespace Ecommerce.Domain.Entities;

public class Role : EntityBase<Guid>
{
    public string Name { get; set; }        // "customer", "staff", "manager", "custom_role_1"
    public string DisplayName { get; set; } // "Cliente", "Empleado", "Gerente", "Rol Personalizado"
    public string Description { get; set; }
    public bool IsSystemRole { get; set; }  // true para roles base, false para personalizados
    public bool IsActive { get; set; }

    // Relaciones
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public virtual ICollection<RolePermission> RolePermissions { get; set; }
}
