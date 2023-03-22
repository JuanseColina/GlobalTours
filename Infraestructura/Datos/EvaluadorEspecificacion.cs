using Core.Especificaciones;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos;

public class EvaluadorEspecificacion<T>  where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, IEspecificaciones<T> especificaciones)
    {
        var query = inputQuery;

        if (especificaciones.Filtro != null)
        {
            query = query.Where(especificaciones.Filtro);// se aplica el filtro
        }
        query = especificaciones.Includes.Aggregate(query, (current, include) => current.Include(include));
        return query;
    }
}
