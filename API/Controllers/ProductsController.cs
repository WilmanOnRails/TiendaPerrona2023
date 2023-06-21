using API.Dtos;
using API.Repositorio;
using AutoMapper;
using Dependencias.Email;
using Dependencias.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("ApiTienda/[Controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductRepository context;
        private readonly IMapper mapper;


        public ProductsController(IProductRepository context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> getProducts()
        {
            var lst = await context.GetAll();
            return Ok(mapper.Map<IEnumerable<ProductDto>>(lst));
        }

        [HttpGet("{productType:int}", Name = "getProductByType")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> getProductByType(int productType)
        {
            var list = await context.GetAll();
            var output = list.Where(x => x.ProductType == productType).ToList();

            return Ok(mapper.Map<IEnumerable<ProductDto>>(output));

        }


        [HttpGet("{Name:alpha}", Name = "getProductByName")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> getProductByName(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name)) return BadRequest();

            var product = await context.Get(x => x.ProductName == Name);

            if (product is null) return NotFound();

            return Ok(product);
        }

        [HttpPut("{id:int}", Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductUpdateDto Product, int id)
        {
            if (id == 0) return BadRequest(ModelState);

            if (Product is null) return BadRequest();

            var ProductToFind = await context.Get(x => x.ProductId == id);

            if (ProductToFind is null) return NotFound();

            await context.Update(mapper.Map<Product>(Product));

            return Ok();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePatch(int id, JsonPatchDocument<ProductUpdateDto> json)
        {
            if (json is null || id == 0) return BadRequest();

            var producto = await context.Get(x => x.ProductId == id, true);

            if (producto is null) return NotFound();

            var productTemp = mapper.Map<ProductUpdateDto>(producto);

            if (!ModelState.IsValid) return BadRequest();

            json.ApplyTo(productTemp, ModelState);


            await context.Update(mapper.Map<Product>(productTemp));

            return NoContent();
        }

    }
}
