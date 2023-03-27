using Domain.Enums;
using Domain.Models.Common;

namespace Domain.Models;

public class Owner : EntityBase, IEntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Identification { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public OwnerType Type { get; set; }
    public List<Vehicle>? Vehicles { get; set; }
    public List<Registration>? Registrations { get; set; }
}
