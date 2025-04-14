namespace ZooManager.Domain.Entities;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string Species { get; set; } = null!;
    public string Habitat { get; set; } = null!;
    public string CountryOfOrigin { get; set; } = null!;

    public ICollection<AnimalCare> AnimalCares { get; set; } = new List<AnimalCare>();
}
