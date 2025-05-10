using Ecommerce.Application.DTOs.Category;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services;

public class CategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();

        return categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            ImageUrl = c.ImageUrl
        });
    }

    public async Task<CategoryDto?> GetByIdAsync(Guid id)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);
        if (category == null) return null;

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            ImageUrl = category.ImageUrl
        };
    }

    public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
    {
        var entity = new Category
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl
        };

        await _unitOfWork.Categories.AddAsync(entity);
        await _unitOfWork.CompleteAsync();

        return new CategoryDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            ImageUrl = entity.ImageUrl
        };
    }

    public async Task<bool> UpdateAsync(Guid id, CreateCategoryDto dto)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);
        if (category == null) return false;

        category.Name = dto.Name;
        category.Description = dto.Description;
        category.ImageUrl = dto.ImageUrl;

        await _unitOfWork.Categories.UpdateAsync(category);
        await _unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);
        if (category == null) return false;

        await _unitOfWork.Categories.DeleteAsync(category);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}