using Domain.Enums;
using Domain.Models.Common;

namespace Domain.Models;

public class Infringement : EntityBase, IEntityBase
{
    public int VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }
    public DateTime Date { get; set; }
    public InfringementActuated InfringementActuated { get; set; }
}
