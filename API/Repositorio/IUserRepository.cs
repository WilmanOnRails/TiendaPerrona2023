using Dependencias.Model;

namespace API.Repositorio
{
    public interface IUserRepository : IRepository<User>
    {
        Task Update(User obj);
    }
}
