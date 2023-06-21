using Dependencias.Model;

namespace API.Repositorio
{
    public interface ICarritoRepository : IRepository<Carrito>
    {
        Task Update(Carrito obj);
    }
}
