using Ecommerce.Application.DTOs.Address;
using Ecommerce.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly AddressService _service;

    public AddressController(AddressService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var a = await _service.GetByIdAsync(id);
        return a == null ? NotFound() : Ok(a);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAddressDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, CreateAddressDto dto)
    {
        var ok = await _service.UpdateAsync(id, dto);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var ok = await _service.DeleteAsync(id);
        return ok ? NoContent() : NotFound();
    }
}