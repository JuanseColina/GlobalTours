using GlobalTours.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GlobalTours.Datos;

public class ApplicationDbContext : DbContext // hereda de una clase de entityFramework
{
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    

    public DbSet<Lugar> Lugares { get; set; }
}