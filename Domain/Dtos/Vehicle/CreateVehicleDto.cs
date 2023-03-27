using Domain.Enums;

namespace Domain.Dtos.Vehicle;

public class CreateVehicleDto
{
    public int OwnerId { get; set; }
    public string Brand { get; set; } = string.Empty;
    public VehicleType VehicleType { get; set; }
    public string Plaque { get; set; } = string.Empty; // vehicle identification number
}
