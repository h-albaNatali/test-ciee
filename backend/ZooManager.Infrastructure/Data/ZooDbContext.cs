using Microsoft.EntityFrameworkCore;
using ZooManager.Domain.Entities;


namespace ZooManager.Infrastructure.Data;

public class ZooDbContext : DbContext
{
    public ZooDbContext(DbContextOptions<ZooDbContext> options) : base(options) { }

    public DbSet<Animal> Animals => Set<Animal>();
    public DbSet<Care> Cares => Set<Care>();
    public DbSet<AnimalCare> AnimalCares => Set<AnimalCare>();
    public DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnimalCare>()
            .HasKey(ac => new { ac.AnimalId, ac.CareId });

        modelBuilder.Entity<AnimalCare>()
            .HasOne(ac => ac.Animal)
            .WithMany(a => a.AnimalCares)
            .HasForeignKey(ac => ac.AnimalId);

        modelBuilder.Entity<AnimalCare>()
            .HasOne(ac => ac.Care)
            .WithMany(c => c.AnimalCares)
            .HasForeignKey(ac => ac.CareId);
    }
}
