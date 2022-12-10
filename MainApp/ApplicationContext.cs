using LabsDB.Entity;
using Microsoft.EntityFrameworkCore;

namespace MainApp;

public class ApplicationContext : DbContext
{
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Room> Room { get; set; } = null!;
    public DbSet<Lamp> Lamp { get; set; } = null!;
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
}