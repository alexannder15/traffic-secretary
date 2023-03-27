using Application.Interfaces;
using Domain.Dtos.Vehicle;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync() =>
        Ok(await _vehicleService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id) =>
        Ok(await _vehicleService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateVehicleDto createVehicleDto) =>
        Ok(await _vehicleService.CreateAsync(createVehicleDto));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateVehicleDto updateVehicleDto)
    {
        await _vehicleService.UpdateAsync(id, updateVehicleDto);
        return Ok("Updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _vehicleService.DeleteAsync(id);
        return Ok("Deleted successfully");
    }
}
