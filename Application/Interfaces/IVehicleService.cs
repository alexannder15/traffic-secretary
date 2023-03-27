using Domain.Dtos.Vehicle;
using Domain.Models;

namespace Application.Interfaces;

public interface IVehicleService
{
    Task<List<VehicleDto>> GetAllAsync();
    Task<VehicleDto?> GetByIdAsync(int id);
    Task<Vehicle> CreateAsync(CreateVehicleDto createVehicleDto);
    Task UpdateAsync(int id, UpdateVehicleDto updateVehicleDto);
    Task DeleteAsync(int id);
}
