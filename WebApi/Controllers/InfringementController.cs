using Application.Interfaces;
using Domain.Dtos.Infringement;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class InfringementController : ControllerBase
{
    private readonly IInfringementService _infringementService;

    public InfringementController(IInfringementService infringementService)
    {
        _infringementService = infringementService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync() =>
        Ok(await _infringementService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id) =>
        Ok(await _infringementService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateInfringementDto createInfringementDto) =>
        Ok(await _infringementService.CreateAsync(createInfringementDto));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateInfringementDto updateInfringementDto)
    {
        await _infringementService.UpdateAsync(id, updateInfringementDto);
        return Ok("Updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _infringementService.DeleteAsync(id);
        return Ok("Deleted successfully");
    }
}
