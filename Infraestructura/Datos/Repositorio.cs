using Core.Especificaciones;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos;

public class Repositorio<T> : IRepositorio<T> where T : class
{
    private readonly ApplicationDbContext _db;

    public Repositorio(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<T> ObtenerAsync(int id)
    {
        return await _db.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ObtenerTodosAsync()
    {
        return await _db.Set<T>().ToListAsync();
    }

    public async Task<T> ObtenerEspec(IEspecificaciones<T> spec)
    {
        return await AplicarEspecificacion(spec).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ObtenerTodosEspec(IEspecificaciones<T> spec)
    {
        return await AplicarEspecificacion(spec).ToListAsync();
    }
    
    private IQueryable<T> AplicarEspecificacion(IEspecificaciones<T> spec)
    {
        return EvaluadorEspecificacion<T>.GetQuery(_db.Set<T>().AsQueryable(), spec);// se usa el evaluador de especificaciones
    }
}