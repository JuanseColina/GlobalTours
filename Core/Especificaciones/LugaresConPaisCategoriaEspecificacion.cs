using System.Linq.Expressions;
using Core.Entidades;

namespace Core.Especificaciones;

public class LugaresConPaisCategoriaEspecificacion : EspecificacionBase<Lugar>
{
    public LugaresConPaisCategoriaEspecificacion()
    {
        AgregarInclude(x => x.Pais);
        AgregarInclude(x => x.Categoria);
    }
    
    public LugaresConPaisCategoriaEspecificacion(int id) : base(x => x.Id == id)
    {
        AgregarInclude(x => x.Pais);
        AgregarInclude(x => x.Categoria);
    }
}
