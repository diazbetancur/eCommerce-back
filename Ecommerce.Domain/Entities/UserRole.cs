namespace Ecommerce.Domain.Entities;

public class UserRole : EntityBase<Guid>
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public bool IsActive { get; set; }
    public DateTime? ExpiresAt { get; set; } // Roles temporales

    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
}
