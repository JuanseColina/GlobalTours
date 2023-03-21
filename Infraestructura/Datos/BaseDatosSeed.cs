using System.Diagnostics;
using System.Text.Json;
using Core.Entidades;
using Microsoft.Extensions.Logging;

namespace Infraestructura.Datos;

public class BaseDatosSeed
{
    
    public static async Task SeedAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
    {
        
        try
        {
            if (!context.Paises.Any())
            {
                var paisData = await File.ReadAllTextAsync("../Infraestructura/Datos/SeedData/paises.json");
                var paises = JsonSerializer.Deserialize<List<Pais>>(paisData);

                foreach (var item in paises)
                {
                    await context.Paises.AddAsync(item);
                }
                await context.SaveChangesAsync();
            }
            if (!context.Categorias.Any())// si no hay categorias
            {
                var categoriasData = File.ReadAllText("../Infraestructura/Datos/SeedData/categorias.json");
                var categorias = JsonSerializer.Deserialize<List<Categoria>>(categoriasData);

                foreach (var item in categorias)
                {
                    await context.Categorias.AddAsync(item);
                }
                await context.SaveChangesAsync();
            }
            if (!context.Lugares.Any())
            {
                var lugaresData = File.ReadAllText("../Infraestructura/Datos/SeedData/lugares.json");
                var lugares = JsonSerializer.Deserialize<List<Lugar>>(lugaresData);

                foreach (var item in lugares)
                {
                    await context.Lugares.AddAsync(item);
                }
                await context.SaveChangesAsync();
            }
        }
        catch (SystemException ex)
        {
            var logger = loggerFactory.CreateLogger<BaseDatosSeed>();
            logger.LogError(ex.Message);
        }
    }
}