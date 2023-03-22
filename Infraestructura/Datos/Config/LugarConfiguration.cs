using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Datos.Config;

public class LugarConfiguration : IEntityTypeConfiguration<Lugar>
{
    /// <summary>
    /// Configuración de la entidad Lugar
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Lugar> builder)
    {
        builder.Property(l => l.Id).IsRequired(); 
        builder.Property(l => l.Nombre).IsRequired().HasMaxLength(100);
        builder.Property(l => l.Descripcion).IsRequired();
        builder.Property(l => l.GastoAproximado).IsRequired();
        
        builder.HasOne(c => c.Categoria) // Lugar tiene una Categoria 
            .WithMany()
            .HasForeignKey(l => l.CategoriaId);
        
        builder.HasOne(p => p.Pais) // Lugar tiene un Pais
            .WithMany()
            .HasForeignKey(l => l.PaisId);
    }
}