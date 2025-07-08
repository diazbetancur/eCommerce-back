using Ecommerce.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities;

public class UserAuthProvider : EntityBase<Guid>
{
    public int UserId { get; set; }
    public AuthProviderType ProviderType { get; set; }
    public string ProviderId { get; set; }
    public string PasswordHash { get; set; }

    public virtual User User { get; set; }
}
