using Core.Especificaciones;

namespace Core.Interfaces;

public interface IRepositorio<T> where T : class
{
    Task<T> ObtenerAsync(int id);
    Task<IReadOnlyList<T>> ObtenerTodosAsync();
    
    Task<T> ObtenerEspec(IEspecificaciones<T> spec);
    
    Task<IReadOnlyList<T>> ObtenerTodosEspec(IEspecificaciones<T> spec);

}