using Ecommerce.Application.DTOs.Product;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services;

public class ProductReviewService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductReviewService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductReviewDto>> GetByProductAsync(Guid productId)
    {
        var reviews = await _unitOfWork.ProductReviews.FindAsync(r => r.ProductId == productId);

        return reviews.Select(r => new ProductReviewDto
        {
            Id = r.Id,
            ProductId = r.ProductId,
            CustomerId = r.CustomerId,
            Rating = r.Rating,
            Comment = r.Comment,
            ReviewDate = r.ReviewDate
        });
    }

    public async Task<ProductReviewDto> CreateAsync(CreateProductReviewDto dto)
    {
        var review = new ProductReview
        {
            Id = Guid.NewGuid(),
            ProductId = dto.ProductId,
            CustomerId = dto.CustomerId,
            Rating = dto.Rating,
            Comment = dto.Comment
        };

        await _unitOfWork.ProductReviews.AddAsync(review);
        await _unitOfWork.CompleteAsync();

        return new ProductReviewDto
        {
            Id = review.Id,
            ProductId = review.ProductId,
            CustomerId = review.CustomerId,
            Rating = review.Rating,
            Comment = review.Comment,
            ReviewDate = review.ReviewDate
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var review = await _unitOfWork.ProductReviews.GetByIdAsync(id);
        if (review == null) return false;

        await _unitOfWork.ProductReviews.DeleteAsync(review);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}