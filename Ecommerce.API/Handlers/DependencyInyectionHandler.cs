using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Services;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.API.Handlers;

public class DependencyInyectionHandler
{
    public static void DepencyInyectionConfig(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration);
        // Registro de DbContext
        // services.AddDbContext<EcommerceDbContext>(options =>
        //     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddDbContext<EcommerceDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<CategoryService>();
        services.AddScoped<ProductService>();
        services.AddScoped<AddressService>();
        services.AddScoped<CartService>();
        services.AddScoped<OrderService>();
        services.AddScoped<ProductReviewService>();
    }
}