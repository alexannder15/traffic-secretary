using Domain.Enums;

namespace Domain.Dtos.Owner;

public class CreateOwnerDto
{
    public string Name { get; set; } = string.Empty;
    public string Identification { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public OwnerType Type { get; set; }
}
