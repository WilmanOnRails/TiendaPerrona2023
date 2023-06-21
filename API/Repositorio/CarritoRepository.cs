using Dependencias.Data;
using Dependencias.Model;

namespace API.Repositorio
{
    public class CarritoRepository : Repository<Carrito>, ICarritoRepository
    {
        private readonly MainContext context;
        public CarritoRepository(MainContext context) : base(context)
        {
            this.context = context;
        }
        public async Task Update(Carrito obj)
        {
            context.ShoppingCart.Update(obj);
            await context.SaveChangesAsync();
        }
    }
}
