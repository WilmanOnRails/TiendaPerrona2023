using API.Dtos;
using API.Repositorio;
using AutoMapper;
using Dependencias.Data;
using Dependencias.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("ApiTienda/[Controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRepository context;
        private readonly ILogger<UsersController> logger;
        private readonly IMapper mapper;

        public UsersController(MainContext context, ILogger<UsersController> logger, IMapper apiMapper, IUserRepository repository)
        {
            this.context = repository;
            this.logger = logger;
            mapper = apiMapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var lst = await context.GetAll();
            return Ok(mapper.Map<List<UserDto>>(lst));
        }

        [HttpGet("{Id:int}", Name = "getUsersById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDto>> GetUsersById(int Id)
        {
            if (Id == 0) return BadRequest();


            var Users = await context.Get(x => x.UserID == Id);

            if (Users is null) return NotFound();

            return Ok(mapper.Map<UserDto>(Users));
        }

        [HttpGet("{str}", Name = "GetUsersByString")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> GetUsersByString(string str)
        {

            if (string.IsNullOrWhiteSpace(str)) return BadRequest();

            var Users = await context.Get(x => x.UserName == str || x.Email == str);

            if (Users is null) return NotFound();


            return Ok(mapper.Map<UserDto>(Users));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] UserPostDto user)
        {
            var searchUser = await context.Get(x => x.UserName.ToUpper() == user.UserName.ToUpper() || x.Email.ToUpper() == user.Email.ToUpper());
            if (searchUser is not null) return BadRequest();



            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (user is null) return BadRequest();


            await context.Add(mapper.Map<User>(user));

            return Ok();
        }

        [HttpPut("{Id:int}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateUser([FromBody] UserUpdateDto userP, int Id)
        {
            if (Id == 0) return BadRequest();

            if (userP is null) return BadRequest();

            var usertofind = await context.Get(x => x.UserID == Id);

            if (usertofind is null) return NotFound();

            usertofind = mapper.Map<User>(userP);

            await context.Update(usertofind);

            return Ok();
        }


        [HttpDelete("Name", Name = "DeleteUserByName")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteUserByName(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name)) return BadRequest(ModelState);

            var user = await context.Get(x => x.UserName.ToUpper() == Name.ToUpper());

            if (user is null)
            {
                logger.LogError("Cannot find the user to delete it.");
                return NotFound(ModelState);
            }

            await context.Delete(user);

            return Ok();
        }

        [HttpDelete("{id:int}", Name = "DeleteUserById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            if (id == 0) return BadRequest();

            var user = await context.Get(x => x.UserID == id);

            if (user is null)
            {
                logger.LogError("Cannot find the user to delete it.");
                return NotFound(ModelState);
            }

            context.Delete(user);

            return Ok();
        }


        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePatch(int id, JsonPatchDocument<ProductUpdateDto> json)
        {
            if (json is null || id == 0) return BadRequest();

            var User = await context.Get(x => x.UserID == id, true);

            if (User is null) return NotFound();

            var UserTemp = mapper.Map<ProductUpdateDto>(User);

            if (!ModelState.IsValid) return BadRequest();

            json.ApplyTo(UserTemp, ModelState);


            context.Update(mapper.Map<User>(UserTemp));

            return NoContent();
        }

    }
}
