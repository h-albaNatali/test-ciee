namespace ZooManager.Domain.Entities;

public class AnimalCare
{
    public int AnimalId { get; set; }
    public Animal Animal { get; set; } = null!;
    
    public int CareId { get; set; }
    public Care Care { get; set; } = null!;
}
