using Application.Interfaces;
using Domain.Dtos.Infringement;
using Domain.Dtos.Vehicle;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class InfringementService : IInfringementService
{
    private readonly IRepository<Infringement> _repository;

    public InfringementService(IRepository<Infringement> repository)
    {
        _repository = repository;
    }

    public async Task<List<InfringementDto>> GetAllAsync()
    {
        var query = await _repository.Query().Include(x => x.Vehicle).ToListAsync();

        return query.Select(x => new InfringementDto
        {
            Id = x.Id,
            Date = x.Date,
            InfringementActuated = x.InfringementActuated,
            VehicleId = x.VehicleId,
            Vehicle = new VehicleDto
            {
                Id = x.Vehicle.Id,
                Brand = x.Vehicle.Brand,
                OwnerId = x.Vehicle.OwnerId,
                Plaque = x.Vehicle.Plaque,
                Type = x.Vehicle.Type
            }
        }).ToList();
    }

    public async Task<InfringementDto?> GetByIdAsync(int id)
    {
        var query = await _repository.Query()
            .Include(x => x.Vehicle)
            .FirstOrDefaultAsync(x => x.Id == id);

        return new InfringementDto
        {
            Id = query.Id,
            VehicleId = query.VehicleId,
            InfringementActuated = query.InfringementActuated,
            Date = query.Date
        };
    }

    public async Task<Infringement> CreateAsync(CreateInfringementDto createInfringementDto)
    {
        Infringement infringement = new()
        {
            VehicleId = createInfringementDto.VehicleId,
            InfringementActuated = createInfringementDto.InfringementActuated,
            Date = DateTime.Now
        };

        return await _repository.AddAsync(infringement);
    }

    public async Task UpdateAsync(int id, UpdateInfringementDto updateInfringementDto)
    {
        Infringement? infringement = await _repository.GetByIdAsync(id) ?? throw new Exception("Infringement not found");

        infringement.VehicleId = updateInfringementDto.VehicleId;
        infringement.InfringementActuated = updateInfringementDto.InfringementActuated;

        await _repository.UpdateAsync(infringement);
    }

    public async Task DeleteAsync(int id)
    {
        Infringement? infringement = await _repository.GetByIdAsync(id) ?? throw new Exception("Infringement not found");
        await _repository.DeleteAsync(infringement);
    }
}
