using Ecommerce.Application.DTOs.Product;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services;

public class ProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _unitOfWork.Products.GetAllAsync();

        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            DiscountPrice = p.DiscountPrice,
            Sku = p.Sku,
            Stock = p.Stock,
            ImageUrl = p.ImageUrl,
            CategoryId = p.CategoryId
        });
    }

    public async Task<ProductDto?> GetByIdAsync(Guid id)
    {
        var p = await _unitOfWork.Products.GetByIdAsync(id);
        if (p == null) throw new NotFoundException($"Producto con ID {id} no encontrado.");

        return new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            DiscountPrice = p.DiscountPrice,
            Sku = p.Sku,
            Stock = p.Stock,
            ImageUrl = p.ImageUrl,
            CategoryId = p.CategoryId
        };
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto dto)
    {
        var entity = new Product
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Price = dto.Price,
            DiscountPrice = dto.DiscountPrice,
            Sku = dto.Sku,
            Stock = dto.Stock,
            ImageUrl = dto.ImageUrl,
            CategoryId = dto.CategoryId
        };

        await _unitOfWork.Products.AddAsync(entity);
        await _unitOfWork.CompleteAsync();

        return new ProductDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            DiscountPrice = entity.DiscountPrice,
            Sku = entity.Sku,
            Stock = entity.Stock,
            ImageUrl = entity.ImageUrl,
            CategoryId = entity.CategoryId
        };
    }

    public async Task<bool> UpdateAsync(Guid id, CreateProductDto dto)
    {
        var p = await _unitOfWork.Products.GetByIdAsync(id);
        if (p == null) return false;

        p.Name = dto.Name;
        p.Price = dto.Price;
        p.DiscountPrice = dto.DiscountPrice;
        p.Sku = dto.Sku;
        p.Stock = dto.Stock;
        p.ImageUrl = dto.ImageUrl;
        p.CategoryId = dto.CategoryId;

        await _unitOfWork.Products.UpdateAsync(p);
        await _unitOfWork.CompleteAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var p = await _unitOfWork.Products.GetByIdAsync(id);
        if (p == null) return false;

        await _unitOfWork.Products.DeleteAsync(p);
        await _unitOfWork.CompleteAsync();

        return true;
    }
}