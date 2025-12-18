using GameUsers.API.Models;
using GameUsers.API.Services;
using GameUsers.Communication.Request;
using GameUsers.Communication.Response;
using Microsoft.AspNetCore.Identity;

namespace GameUsers.API.UseCase.Login
{
    public class LoginUserUseCase : ILoginUserUseCase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenService _tokenService;
        public LoginUserUseCase(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task<AuthResponse> ExecuteAsync(LoginUserRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username) ?? throw new DomainException("Invalid credentials.");

            var validPassword = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);

            if (!validPassword.Succeeded)
            {
                throw new DomainException("Invalid Password.");
            }

            var token = _tokenService.CreateToken(user);

            return new AuthResponse(token);

        }
    }
}
