

namespace Ecommerce.Domain.Entities;

public class RolePermission : EntityBase<Guid>
{
    public Guid RoleId { get; set; }
    public Guid PermissionId { get; set; }
    public bool IsGranted { get; set; } // true = concedido, false = denegado

    public virtual Role Role { get; set; }
    public virtual Permission Permission { get; set; }
}