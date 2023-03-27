namespace Domain.Dtos.Registration;

public class UpdateRegistrationDto
{
    public int VehicleId { get; set; }
    public int OwnerId { get; set; }
    public DateTime RegistrationDate { get; set; }
}
