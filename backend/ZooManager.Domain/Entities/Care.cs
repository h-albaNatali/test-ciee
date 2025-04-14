namespace ZooManager.Domain.Entities;

public class Care
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Frequency { get; set; } = null!;

    public ICollection<AnimalCare> AnimalCares { get; set; } = new List<AnimalCare>();
}
