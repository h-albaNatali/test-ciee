namespace ZooManager.Application.DTOs;

public class AnimalDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime BirthDate { get; set; }
    public string Species { get; set; } = default!;
    public string Habitat { get; set; } = default!;
    public string CountryOfOrigin { get; set; } = default!;
    public List<CareDto> Cares { get; set; } = new();
}
