using System.Linq.Expressions;

namespace Core.Especificaciones;

public interface IEspecificaciones<T>
{
    Expression<Func<T, bool>> Filtro { get; }
    List<Expression<Func<T, object>>> Includes { get; }
}