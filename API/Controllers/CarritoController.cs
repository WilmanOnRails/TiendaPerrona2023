using API.Dtos;
using API.Repositorio;
using AutoMapper;
using Dependencias.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("ApiTienda/[Controller]")]
    [ApiController]
    public class CarritoController : Controller
    {
        private readonly ICarritoRepository context;
        private readonly IMapper mapper;


        public CarritoController(ICarritoRepository context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CarritoDto>>> getProductsInCart()
        {
            var lst = await context.GetAll();
            return Ok(mapper.Map<IEnumerable<CarritoDto>>(lst));
        }


        [HttpGet("{Name}", Name = "getCartProductByName")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CarritoDto>> getCartProductByName(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name)) return BadRequest();

            var product = await context.Get(x => x.ProductName == Name);

            if (product is null) return NotFound();

            return Ok(product);
        }

        [HttpPut("{id:int}", Name = "UpdateCartProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateCartProduct([FromBody] CarritoDto Product, string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return BadRequest(ModelState);

            if (Product is null) return BadRequest();

            var ProductToFind = await context.Get(x => x.ProductName == name);

            if (ProductToFind is null) return NotFound();

            await context.Update(mapper.Map<Carrito>(Product));

            return Ok();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePatch(string name, JsonPatchDocument<CarritoDto> json)
        {
            if (json is null || string.IsNullOrWhiteSpace(name)) return BadRequest();

            var producto = await context.Get(x => x.ProductName == name, true);

            if (producto is null) return NotFound();

            var productTemp = mapper.Map<CarritoDto>(producto);

            if (!ModelState.IsValid) return BadRequest();

            json.ApplyTo(productTemp, ModelState);


           await  context.Update(mapper.Map<Carrito>(productTemp));

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddProductCart([FromBody] CarritoPostDto user)
        {
            var searchUser = await context.Get(x => x.ProductName.ToUpper() == user.ProductName.ToUpper());
            if (searchUser is not null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (user is null) return BadRequest();

            var porra = mapper.Map<Carrito>(user);
            porra.Total = porra.ProductPrice * porra.Quantity;

            await context.Add(porra);

            return Ok();
        }

        [HttpDelete("Name", Name = "DeleteProductCartByName")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteProductCartByName(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name)) return BadRequest(ModelState);

            var user = await context.Get(x => x.ProductName.ToUpper() == Name.ToUpper());

            if (user is null) return NotFound(ModelState);


            await context.Delete(user);

            return Ok();
        }
    }
}
