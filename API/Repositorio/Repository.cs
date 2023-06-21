using Dependencias.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Repositorio
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MainContext context;
        private readonly DbSet<T> tabla;

        public Repository(MainContext context)
        {
            this.context = context;
            tabla= context.Set<T>();
        }

        public async Task Delete(T obj)
        {
            tabla.Remove(obj);

            await GuardarCambios();
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, bool tracking = false)
        {
            var query = tabla.AsQueryable();
            if (tracking) query.AsNoTracking();

            return await query.Where(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll(bool tracking = false)
        {
            var query = tabla.AsQueryable();
            if (tracking) query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task GuardarCambios()
        {
            await context.SaveChangesAsync();
        }

        public async Task Add(T obj)
        {
            await context.AddAsync(obj);
            await GuardarCambios();
        }

        
    }
}
