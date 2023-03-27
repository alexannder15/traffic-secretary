using Domain.Models.Common;

namespace Domain.Models;

public class Registration : EntityBase, IEntityBase
{
    public int VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }
    public int OwnerId { get; set; }
    public Owner? Owner { get; set; }
    public DateTime RegistrationDate { get; set; }
}
