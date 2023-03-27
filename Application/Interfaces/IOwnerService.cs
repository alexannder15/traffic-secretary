using Domain.Dtos.Owner;
using Domain.Models;

namespace Application.Interfaces;

public interface IOwnerService
{
    Task<List<OwnerDto>> GetAllAsync();
    Task<OwnerDto?> GetByIdAsync(int id);
    Task<Owner> CreateAsync(CreateOwnerDto createOwnerDto);
    Task UpdateAsync(int id, UpdateOwnerDto updateOwnerDto);
    Task DeleteAsync(int id);
}
