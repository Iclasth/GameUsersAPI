using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GameUsers.API.Models;
using GameUsers.API.Services;
using GameUsers.Communication.Request;
using GameUsers.API.UseCase.Register;
using GameUsers.API.UseCase.Login;
using GameUsers.Communication.Response;

namespace GameUsers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IRegisterUserUseCase _register;
        private readonly ILoginUserUseCase _Login;

        public UserController(IRegisterUserUseCase register, ILoginUserUseCase login)
        {
            _register = register;
            _Login = login;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(RegisterUserRequest request)
        {
            var user = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email,
                DisplayName = request.DisplayName ?? request.Username
            };

            var response = await _register.RegisterAsync(user, request.Password);

            
            return Ok(response);
        }
        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok();
        }
        [HttpGet("me")]
        public IActionResult GetUsers()
        {
            return Ok();
        }
        
    }
}
