using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Data;

namespace Ecommerce.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly EcommerceDbContext _context;

    public UnitOfWork(EcommerceDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<Category> Categories => new GenericRepository<Category>(_context);
    public IGenericRepository<Product> Products => new GenericRepository<Product>(_context);
    public IGenericRepository<Customer> Customers => new GenericRepository<Customer>(_context);
    public IGenericRepository<Order> Orders => new GenericRepository<Order>(_context);
    public IGenericRepository<Cart> Carts => new GenericRepository<Cart>(_context);

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}