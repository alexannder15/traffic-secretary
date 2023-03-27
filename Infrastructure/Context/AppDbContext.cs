using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Vehicle>? Vehicles { get; set; }
    public DbSet<Vehicle>? Owners { get; set; }
    public DbSet<Registration>? Registrations { get; set; }
    public DbSet<Infringement>? Infringements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>()
        .HasData(SeedData.SetVehiclesSeedData());
        modelBuilder.Entity<Vehicle>()
            .HasOne(x => x.Owner)
            .WithMany(x => x.Vehicles)
            .HasForeignKey(x => x.OwnerId);
        modelBuilder.Entity<Vehicle>()
            .HasMany(x => x.Registrations);
        modelBuilder.Entity<Vehicle>()
            .HasMany(x => x.Infringements);


        modelBuilder.Entity<Owner>()
            .HasData(SeedData.SetOwnerSeedData());
        modelBuilder.Entity<Owner>()
            .HasMany(x => x.Vehicles);
        modelBuilder.Entity<Owner>()
            .HasMany(x => x.Registrations);


        modelBuilder.Entity<Registration>()
            .HasData(SeedData.SetRegistrationSeedData());
        modelBuilder.Entity<Registration>()
            .HasOne(x => x.Owner)
            .WithMany(x => x.Registrations)
            .HasForeignKey(x => x.OwnerId);
        modelBuilder.Entity<Registration>()
            .HasOne(x => x.Vehicle)
            .WithMany(x => x.Registrations)
            .HasForeignKey(x => x.VehicleId);


        modelBuilder.Entity<Infringement>()
            .HasData(SeedData.SetInfringementSeedData());
        modelBuilder.Entity<Infringement>()
            .HasOne(x => x.Vehicle)
            .WithMany(x => x.Infringements)
            .HasForeignKey(x => x.VehicleId);

        base.OnModelCreating(modelBuilder);
    }
}
