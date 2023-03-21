using Core.Entidades;

namespace Core.Interfaces;

public interface ILugarRepositorio
{
    // firmas de nuestros metodos
    
    Task<Lugar> GetLugarAsync(int id);

    Task<IReadOnlyList<Lugar>> GetLugaresAsync();
    
}