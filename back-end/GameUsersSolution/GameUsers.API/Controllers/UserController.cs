using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GameUsers.API.Models;
using GameUsers.API.Services;
using GameUsers.Communication.Request;
using GameUsers.API.UseCase.Register;
using GameUsers.API.UseCase.Login;
using GameUsers.Communication.Response;
using GameUsers.API.UseCase.GetUserById;
using GameUsers.API.UseCase.Delete;
using GameUsers.API.UseCase.Update;

namespace GameUsers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IRegisterUserUseCase _register;
        private readonly ILoginUserUseCase _Login;
        private readonly IGetUserByIdUseCase _getById;
        private readonly IUpdateUserUseCase _update;
        private readonly IDeleteUserUseCase _delete;

        public UserController(IRegisterUserUseCase register, ILoginUserUseCase login, IGetUserByIdUseCase getById, IUpdateUserUseCase update, IDeleteUserUseCase delete)
        {
            _register = register;
            _Login = login;
            _getById = getById;
            _update = update;
            _delete = delete;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthResponse>> Register([FromBody]RegisterUserRequest request)
        {
            var user = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email,
                DisplayName = request.DisplayName ?? request.Username
            };

            var response = await _register.ExecuteAsync(request);

            
            return Created(string.Empty, response);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthResponse>> Login([FromBody]LoginUserRequest request)
        {
            var response = _Login.ExecuteAsync(request);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ResponseShortUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuthResponse>> GetUserById(int id)
        {
            var response = _getById.ExecuteAsync(id);

            if (response == null) return NotFound("Usuário não encontrado");

            return Ok(response);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseShortUserJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseShortUserJson), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuthResponse>> Update(int id, RegisterUserRequest novosDados)
        {
            var response = _update.ExecuteAsync(id, novosDados);

            return NoContent();
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseShortUserJson),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuthResponse>> Delete(int id)
        {
            var response = _delete.ExecuteAsync(id);

            return NoContent();
        }
        
    }
}
