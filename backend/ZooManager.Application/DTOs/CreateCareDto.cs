namespace ZooManager.Application.DTOs;

public class CreateCareDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Frequency { get; set; } = default!;
}
