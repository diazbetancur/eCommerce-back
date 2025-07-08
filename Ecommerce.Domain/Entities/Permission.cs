

namespace Ecommerce.Domain.Entities;

public class Permission : EntityBase<Guid>
{
    public string Name { get; set; }        // "view_products", "manage_orders", "create_users"
    public string DisplayName { get; set; } // "Ver Productos", "Gestionar Pedidos"
    public string Module { get; set; }      // "products", "orders", "users", "restaurant"
    public string Category { get; set; }    // "view", "create", "edit", "delete", "manage"
    public bool IsActive { get; set; }

    // Relaciones
    public virtual ICollection<RolePermission> RolePermissions { get; set; }
    public virtual ICollection<UserPermission> UserPermissions { get; set; }
}
