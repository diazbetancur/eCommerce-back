using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Category> Categories { get; }
    IGenericRepository<Product> Products { get; }
    IGenericRepository<Customer> Customers { get; }
    IGenericRepository<Order> Orders { get; }
    IGenericRepository<Address> Addresses { get; }
    IGenericRepository<OrderItem> OrderItems { get; }
    IGenericRepository<CartItem> CartItems { get; }

    Task<int> CompleteAsync();
}