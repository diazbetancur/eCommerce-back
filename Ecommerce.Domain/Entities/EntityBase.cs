using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities;

public abstract class EntityBase<T>
{
    [Key]
    public T Id { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}