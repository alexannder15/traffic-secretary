using Application.Interfaces;
using Domain.Dtos.Registration;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class RegistrationController : ControllerBase
{
    private readonly IRegistrationService _registrationService;

    public RegistrationController(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync() =>
        Ok(await _registrationService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _registrationService.GetByIdAsync(id);

        if (result == null)
            return NotFound($"registration with id: {id} not found");

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateRegistrationDto createRegistrationDto) =>
        Ok(await _registrationService.CreateAsync(createRegistrationDto));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateRegistrationDto updateRegistrationDto)
    {
        await _registrationService.UpdateAsync(id, updateRegistrationDto);
        return Ok("Updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _registrationService.DeleteAsync(id);
        return Ok("Deleted successfully");
    }
}
