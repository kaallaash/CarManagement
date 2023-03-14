using CarManagement.Models;
using CarManagement.Models.Car;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.Migrations.Context;

public class DatabaseContext : DbContext
{
    public DbSet<CarModel> Cars { get; set; } = null!;
    public DbSet<UserModel> Users { get; set; } = null!;

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        if (base.Database.IsRelational())
        {
            base.Database.Migrate();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>().HasIndex(u => u.Username).IsUnique();
    }
}