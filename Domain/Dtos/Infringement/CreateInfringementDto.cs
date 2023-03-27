using Domain.Enums;

namespace Domain.Dtos.Infringement;

public class CreateInfringementDto
{
    public int VehicleId { get; set; }
    public InfringementActuated InfringementActuated { get; set; }
}
