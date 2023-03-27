using Domain.Dtos.Registration;
using Domain.Models;

namespace Application.Interfaces;

public interface IRegistrationService
{
    Task<List<RegistrationDto>> GetAllAsync();
    Task<RegistrationDto?> GetByIdAsync(int id);
    Task<Registration> CreateAsync(CreateRegistrationDto createRegistrationDto);
    Task UpdateAsync(int id, UpdateRegistrationDto updateRegistrationDto);
    Task DeleteAsync(int id);
}
