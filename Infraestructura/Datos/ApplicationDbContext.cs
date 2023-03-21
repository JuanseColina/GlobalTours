using System.Reflection;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos;

public class ApplicationDbContext : DbContext // hereda de una clase de entityFramework
{
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    

    public DbSet<Pais> Paises { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Lugar> Lugares { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)// se ejecuta cuando se crea el modelo y crea las migraciones
    {
        base.OnModelCreating(modelBuilder);// se ejecuta el metodo de la clase base
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());// se le pasa el assembly actual
    }
}