using Microsoft.AspNetCore.Mvc;

namespace GameUsers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok();
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
