using Dependencias.Model;

namespace API.Repositorio
{
    public interface IProductRepository : IRepository<Product>
    {
        Task Update(Product obj);
    }
}
