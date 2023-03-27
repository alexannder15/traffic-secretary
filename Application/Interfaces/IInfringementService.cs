using Domain.Dtos.Infringement;
using Domain.Models;

namespace Application.Interfaces;

public interface IInfringementService
{
    Task<List<InfringementDto>> GetAllAsync();
    Task<InfringementDto?> GetByIdAsync(int id);
    Task<Infringement> CreateAsync(CreateInfringementDto createVehicleDto);
    Task UpdateAsync(int id, UpdateInfringementDto updateVehicleDto);
    Task DeleteAsync(int id);
}
