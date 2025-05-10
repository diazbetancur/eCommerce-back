using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.API.Handlers;

public class DependencyInyectionHandler
{
    public static void DepencyInyectionConfig(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration);
        // Registro de DbContext
        services.AddDbContext<EcommerceDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}