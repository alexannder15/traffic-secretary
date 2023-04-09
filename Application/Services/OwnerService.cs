using Application.Interfaces;
using Domain.Dtos.Owner;
using Domain.Dtos.Registration;
using Domain.Dtos.Vehicle;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class OwnerService : IOwnerService
{
    private readonly IRepository<Owner> _repository;

    public OwnerService(IRepository<Owner> repository)
    {
        _repository = repository;
    }

    public async Task<List<OwnerDto>> GetAllAsync()
    {
        var query = await _repository.Query()
            .Include(x => x.Registrations)
            .Include(x => x.Vehicles)
            .ToListAsync();

        return query.Select(x => new OwnerDto
        {
            Id = x.Id,
            Name = x.Name,
            Type = x.Type,
            Address = x.Address,
            Identification = x.Identification,
            Vehicles = x.Vehicles.Select(y => new VehicleDto
            {
                Id = y.Id,
                Type = y.Type,
                Brand = y.Brand,
                OwnerId = y.OwnerId,
                Plaque = y.Plaque
            }).ToList(),
            Registrations = x.Registrations.Select(z => new RegistrationDto
            {
                Id = z.Id,
                OwnerId = z.OwnerId,
                VehicleId = z.VehicleId,
                RegistrationDate = z.RegistrationDate
            }).ToList(),
        }).ToList();
    }

    public async Task<OwnerDto?> GetByIdAsync(int id)
    {
        var query = await _repository.GetByIdAsync(id);

        if (query == null)
            return null;

        return new OwnerDto
        {
            Id = query.Id,
            Name = query.Name,
            Type = query.Type,
            Address = query.Address,
            Identification = query.Identification
        };
    }

    public async Task<Owner> CreateAsync(CreateOwnerDto createOwnerDto)
    {
        Owner owner = new()
        {
            Name = createOwnerDto.Name,
            Identification = createOwnerDto.Identification,
            Address = createOwnerDto.Address,
            Type = createOwnerDto.Type
        };

        return await _repository.AddAsync(owner);
    }

    public async Task UpdateAsync(int id, UpdateOwnerDto updateOwnerDto)
    {
        Owner? owner = await _repository.GetByIdAsync(id) ?? throw new Exception("Owner not found");

        owner.Name = updateOwnerDto.Name;
        owner.Identification = updateOwnerDto.Identification;
        owner.Address = updateOwnerDto.Address;
        owner.Type = updateOwnerDto.Type;

        await _repository.UpdateAsync(owner);
    }

    public async Task DeleteAsync(int id)
    {
        Owner? vehicle = await _repository.GetByIdAsync(id) ?? throw new Exception("Owner not found");
        await _repository.DeleteAsync(vehicle);
    }
}
