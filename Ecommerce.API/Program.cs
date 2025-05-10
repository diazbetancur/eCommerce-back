using Ecommerce.API.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Configuración de dependencias
DependencyInyectionHandler.DepencyInyectionConfig(builder.Services, builder.Configuration);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();