using Domain.Enums;

namespace Domain.Dtos.Infringement;

public class UpdateInfringementDto
{
    public int VehicleId { get; set; }
    public DateTime Date { get; set; }
    public InfringementActuated InfringementActuated { get; set; }
}
