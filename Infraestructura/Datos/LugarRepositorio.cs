using Core.Entidades;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos;

public class LugarRepositorio : ILugarRepositorio
{
    private readonly ApplicationDbContext _db;

    public LugarRepositorio(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<Lugar> GetLugarAsync(int id)
    {
        return await _db.Lugares.Include(p=> p.Pais) // se incluye el pais
            .Include(c=>c.Categoria) // se incluye la categoria
            .FirstOrDefaultAsync(l=>l.Id == id);// se busca el lugar por id
    }

    public async Task<IReadOnlyList<Lugar>> GetLugaresAsync()
    {
        
        return await _db.Lugares
            .Include(p=> p.Pais)// se incluye el pais
            .Include(c=>c.Categoria)// se incluye la categoria
            .ToListAsync();// se convierte a lista
    }
}