using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SafariAnimals
{
  public partial class AnimalSeenContext : DbContext
  {
    public AnimalSeenContext()
    {
    }
    public DbSet<SafariAnimalsSeen> SafariAnimalsSeen { get; set; }
    public AnimalSeenContext(DbContextOptions<AnimalSeenContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseNpgsql("server=localhost;database=AnimalSeen;User Id=dev;Password=dev");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");
    }
  }
}
