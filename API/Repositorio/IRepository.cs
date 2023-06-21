using System.Linq.Expressions;

namespace API.Repositorio
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(bool tracking = false);
        Task<T> Get(Expression<Func<T, bool>> expression, bool tracking = false);

        Task Add(T obj);

        Task Delete(T obj);

        Task GuardarCambios();
    }
}
