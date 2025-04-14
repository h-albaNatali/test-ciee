namespace ZooManager.Application.DTOs;

public class CareDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Frequency { get; set; } = default!;
}
