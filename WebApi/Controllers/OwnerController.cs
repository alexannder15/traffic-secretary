using Application.Interfaces;
using Domain.Dtos.Owner;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class OwnerController : ControllerBase
{
    private readonly IOwnerService _ownerService;

    public OwnerController(IOwnerService ownerService)
    {
        _ownerService = ownerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync() =>
        Ok(await _ownerService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id) =>
        Ok(await _ownerService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateOwnerDto createVehicleDto) =>
        Ok(await _ownerService.CreateAsync(createVehicleDto));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateOwnerDto updateVehicleDto)
    {
        await _ownerService.UpdateAsync(id, updateVehicleDto);
        return Ok("Updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _ownerService.DeleteAsync(id);
        return Ok("Deleted successfully");
    }
}
