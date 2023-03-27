using Domain.Dtos.Vehicle;
using Domain.Enums;
using Domain.Models.Common;

namespace Domain.Dtos.Infringement;

public class InfringementDto : EntityBase
{
    public int VehicleId { get; set; }
    public VehicleDto? Vehicle { get; set; }
    public DateTime Date { get; set; }
    public InfringementActuated InfringementActuated { get; set; }
}
