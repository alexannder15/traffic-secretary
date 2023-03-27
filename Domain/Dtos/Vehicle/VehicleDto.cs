using Domain.Dtos.Infringement;
using Domain.Dtos.Owner;
using Domain.Dtos.Registration;
using Domain.Enums;
using Domain.Models.Common;

namespace Domain.Dtos.Vehicle;

public class VehicleDto : EntityBase
{
    public int OwnerId { get; set; }
    public OwnerDto? Owner { get; set; }
    public string Brand { get; set; } = string.Empty;
    public VehicleType Type { get; set; }
    public string Plaque { get; set; } = string.Empty;
    public List<RegistrationDto>? Registrations { get; set; }
    public List<InfringementDto>? Infringements { get; set; }
}
