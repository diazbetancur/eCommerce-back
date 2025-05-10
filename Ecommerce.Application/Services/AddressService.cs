using Ecommerce.Application.DTOs.Address;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services;

public class AddressService
{
    private readonly IUnitOfWork _unitOfWork;

    public AddressService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<AddressDto>> GetAllAsync()
    {
        var addresses = await _unitOfWork.Addresses.GetAllAsync();
        return addresses.Select(a => new AddressDto
        {
            Id = a.Id,
            Street = a.Street,
            City = a.City,
            Department = a.Department,
            ZipCode = a.ZipCode,
            Country = a.Country,
            CustomerId = a.CustomerId
        });
    }

    public async Task<AddressDto?> GetByIdAsync(Guid id)
    {
        var a = await _unitOfWork.Addresses.GetByIdAsync(id);
        if (a == null) return null;

        return new AddressDto
        {
            Id = a.Id,
            Street = a.Street,
            City = a.City,
            Department = a.Department,
            ZipCode = a.ZipCode,
            Country = a.Country,
            CustomerId = a.CustomerId
        };
    }

    public async Task<AddressDto> CreateAsync(CreateAddressDto dto)
    {
        var address = new Address
        {
            Id = Guid.NewGuid(),
            Street = dto.Street,
            City = dto.City,
            Department = dto.Department,
            ZipCode = dto.ZipCode,
            Country = dto.Country,
            CustomerId = dto.CustomerId
        };

        await _unitOfWork.Addresses.AddAsync(address);
        await _unitOfWork.CompleteAsync();

        return new AddressDto
        {
            Id = address.Id,
            Street = address.Street,
            City = address.City,
            Department = address.Department,
            ZipCode = address.ZipCode,
            Country = address.Country,
            CustomerId = address.CustomerId
        };
    }

    public async Task<bool> UpdateAsync(Guid id, CreateAddressDto dto)
    {
        var address = await _unitOfWork.Addresses.GetByIdAsync(id);
        if (address == null) return false;

        address.Street = dto.Street;
        address.City = dto.City;
        address.Department = dto.Department;
        address.ZipCode = dto.ZipCode;
        address.Country = dto.Country;
        address.CustomerId = dto.CustomerId;

        await _unitOfWork.Addresses.UpdateAsync(address);
        await _unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var address = await _unitOfWork.Addresses.GetByIdAsync(id);
        if (address == null) return false;

        await _unitOfWork.Addresses.DeleteAsync(address);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}