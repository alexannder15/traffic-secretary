using Application.Interfaces;
using Domain.Dtos.Owner;
using Domain.Dtos.Vehicle;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class VehicleService : IVehicleService
{
    private readonly IRepository<Vehicle> _repository;

    public VehicleService(IRepository<Vehicle> repository)
    {
        _repository = repository;
    }

    public async Task<List<VehicleDto>> GetAllAsync()
    {
        var query = await _repository.Query()
            .Include(x => x.Owner)
            .Include(x => x.Infringements)
            .Include(x => x.Registrations)
            .ToListAsync();

        return query.Select(x => new VehicleDto
        {
            Id = x.Id,
            Brand = x.Brand,
            Plaque = x.Plaque,
            Type = x.Type,
            OwnerId = x.OwnerId,
            Owner = new OwnerDto
            {
                Id = x.Owner.Id,
                Type = x.Owner.Type,
                Address = x.Owner.Address,
                Identification = x.Owner.Identification,
                Name = x.Owner.Name
            }
        }).ToList();
    }

    public async Task<VehicleDto?> GetByIdAsync(int id)
    {
        var query = await _repository.GetByIdAsync(id);

        if (query == null)
            return null;

        return new VehicleDto
        {
            Id = query.Id,
            Brand = query.Brand,
            OwnerId = query.OwnerId,
            Plaque = query.Plaque,
            Type = query.Type
        };
    }

    public async Task<Vehicle> CreateAsync(CreateVehicleDto createVehicleDto)
    {
        Vehicle vehicle = new()
        {
            OwnerId = createVehicleDto.OwnerId,
            Brand = createVehicleDto.Brand,
            Type = createVehicleDto.VehicleType,
            Plaque = createVehicleDto.Plaque
        };

        return await _repository.AddAsync(vehicle);
    }

    public async Task UpdateAsync(int id, UpdateVehicleDto updateVehicleDto)
    {
        Vehicle? vehicle = await _repository.GetByIdAsync(id) ?? throw new Exception("Vehicle not found");
        vehicle.OwnerId = updateVehicleDto.OwnerId;
        vehicle.Brand = updateVehicleDto.Brand;
        vehicle.Type = updateVehicleDto.VehicleType;
        vehicle.Plaque = updateVehicleDto.Plaque;

        await _repository.UpdateAsync(vehicle);
    }

    public async Task DeleteAsync(int id)
    {
        Vehicle? vehicle = await _repository.GetByIdAsync(id) ?? throw new Exception("Vehicle not found");
        await _repository.DeleteAsync(vehicle);
    }
}
