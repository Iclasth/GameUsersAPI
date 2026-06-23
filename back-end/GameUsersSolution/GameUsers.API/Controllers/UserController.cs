using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GameUsers.API.Models;
using GameUsers.API.Services;
using GameUsers.Communication.Request;
using GameUsers.API.UseCase.Register;
using GameUsers.API.UseCase.Login;
using GameUsers.Communication.Response;
using GameUsers.API.UseCase.GetUserById;

namespace GameUsers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IRegisterUserUseCase _register;
        private readonly ILoginUserUseCase _Login;
        private readonly IGetUserByIdUseCase _getById;
        // private readonly IUpdateUserUseCase _update;
        // private readonly IDeleteUserUseCase _delete;

        public UserController(IRegisterUserUseCase register, ILoginUserUseCase login, IGetUserByIdUseCase getById)
        {
            _register = register;
            _Login = login;
            _getById = getById;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register([FromBody]RegisterUserRequest request)
        {
            var user = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email,
                DisplayName = request.DisplayName ?? request.Username
            };

            var response = await _register.ExecuteAsync(request);

            
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody]LoginUserRequest request)
        {
            var response = _Login.ExecuteAsync(request);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AuthResponse>> GetUserById(int id)
        {
            var response = _getById.ExecuteAsync(id);

            if (response == null) return NotFound("Usuário não encontrado");

            return Ok(response);
        }

        [HttpGet("update")]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpGet("delete")]
        public IActionResult Delete()
        {
            return Ok();
        }
        
    }
}
