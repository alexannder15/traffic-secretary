using Application.Interfaces;
using Domain.Dtos.Owner;
using Domain.Dtos.Registration;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class RegistrationService : IRegistrationService
{
    private readonly IRepository<Registration> _repository;

    public RegistrationService(IRepository<Registration> repository)
    {
        _repository = repository;
    }

    public async Task<List<RegistrationDto>> GetAllAsync()
    {
        var query = await _repository.Query()
            .Include(x => x.Owner)
            .ToListAsync();

        return query.Select(x => new RegistrationDto
        {
            Id = x.Id,
            OwnerId = x.OwnerId,
            Owner = new OwnerDto
            {
                Id = x.Owner.Id,
                Address = x.Owner.Address,
                Identification = x.Owner.Identification,
                Name = x.Owner.Name,
                Type = x.Owner.Type
            },
            RegistrationDate = x.RegistrationDate,
            VehicleId = x.VehicleId,
        }).ToList();
    }

    public async Task<RegistrationDto?> GetByIdAsync(int id)
    {
        var query = await _repository.GetByIdAsync(id);

        if (query == null)
            return null;

        return new RegistrationDto
        {
            Id = query.Id,
            OwnerId = query.OwnerId,
            VehicleId = query.VehicleId,
            RegistrationDate = query.RegistrationDate
        };
    }

    public async Task<Registration> CreateAsync(CreateRegistrationDto createRegistrationDto)
    {
        Registration registration = new()
        {
            OwnerId = createRegistrationDto.OwnerId,
            VehicleId = createRegistrationDto.VehicleId,
            RegistrationDate = DateTime.Now
        };

        return await _repository.AddAsync(registration);
    }

    public async Task UpdateAsync(int id, UpdateRegistrationDto updateRegistrationDto)
    {
        Registration? registration = await _repository.GetByIdAsync(id) ?? throw new Exception("Registration not found");

        registration.VehicleId = updateRegistrationDto.VehicleId;
        registration.OwnerId = updateRegistrationDto.OwnerId;

        await _repository.UpdateAsync(registration);
    }

    public async Task DeleteAsync(int id)
    {
        Registration? registration = await _repository.GetByIdAsync(id) ?? throw new Exception("Registration not found");
        await _repository.DeleteAsync(registration);
    }
}
