using hakaton_2022_backend.Core.Configurations;
using hakaton_2022_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace hakaton_2022_backend.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Config> Configs { get; set; }
    public virtual DbSet<Enterprise> Enterprises { get; set; }
    public virtual DbSet<Estimation> Estimations { get; set; }
    public virtual DbSet<Parameters> Parameters { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConfigConfiguration());
        modelBuilder.ApplyConfiguration(new EnterpriseConfiguration());
        modelBuilder.ApplyConfiguration(new EstimationConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ParametersConfiguration());
    }
    
}