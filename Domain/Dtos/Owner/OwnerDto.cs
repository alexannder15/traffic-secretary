using Domain.Dtos.Registration;
using Domain.Dtos.Vehicle;
using Domain.Enums;
using Domain.Models.Common;

namespace Domain.Dtos.Owner;

public class OwnerDto : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Identification { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public OwnerType Type { get; set; }
    public List<VehicleDto>? Vehicles { get; set; }
    public List<RegistrationDto>? Registrations { get; set; }
}
