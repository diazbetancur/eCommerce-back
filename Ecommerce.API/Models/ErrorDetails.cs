namespace Ecommerce.API.Models;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public string? Exception { get; set; }
    public List<string>? Errors { get; set; } = new(); // Opcional, para múltiples errores (ej. validaciones)
}