using Domain.Enums;
using Domain.Models.Common;

namespace Domain.Models;

public class Vehicle : EntityBase, IEntityBase
{
    public int OwnerId { get; set; }
    public Owner? Owner { get; set; }
    public string Brand { get; set; } = string.Empty;
    public VehicleType Type { get; set; }
    public string Plaque { get; set; } = string.Empty;
    public List<Registration>? Registrations { get; set; }
    public List<Infringement>? Infringements { get; set; }
}
