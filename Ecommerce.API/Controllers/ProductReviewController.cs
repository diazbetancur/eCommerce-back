using Ecommerce.Application.DTOs.Product;
using Ecommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductReviewController : ControllerBase
{
    private readonly ProductReviewService _service;

    public ProductReviewController(ProductReviewService service)
    {
        _service = service;
    }

    [HttpGet("product/{productId}")]
    public async Task<IActionResult> GetByProduct(Guid productId)
    {
        var result = await _service.GetByProductAsync(productId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductReviewDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetByProduct), new { productId = dto.ProductId }, created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}