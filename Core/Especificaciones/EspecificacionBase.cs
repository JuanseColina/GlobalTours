using System.Linq.Expressions;

namespace Core.Especificaciones;

public class EspecificacionBase<T> : IEspecificaciones<T>
{
    public EspecificacionBase(Expression<Func<T, bool>> filtro)
    {
        Filtro = filtro;
    }

    public EspecificacionBase()
    {
    }

    public Expression<Func<T, bool>> Filtro { get; }

    public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
    
    protected void AgregarInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }
}