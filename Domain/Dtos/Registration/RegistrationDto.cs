using Domain.Dtos.Owner;
using Domain.Dtos.Vehicle;
using Domain.Models.Common;

namespace Domain.Dtos.Registration;

public class RegistrationDto : EntityBase
{
    public int VehicleId { get; set; }
    public VehicleDto? Vehicle { get; set; }
    public int OwnerId { get; set; }
    public OwnerDto? Owner { get; set; }
    public DateTime RegistrationDate { get; set; }
}
