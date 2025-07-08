

namespace Ecommerce.Domain.Entities;

public class UserPermission : EntityBase<Guid>
{
    public Guid UserId { get; set; }
    public Guid PermissionId { get; set; }
    public bool IsGranted { get; set; } // Overrides del rol
    public DateTime? ExpiresAt { get; set; }

    public virtual User User { get; set; }
    public virtual Permission Permission { get; set; }
}
