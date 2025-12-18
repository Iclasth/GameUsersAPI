using GameUsers.API.Models;
using GameUsers.API.Services;
using GameUsers.Communication.Request;
using GameUsers.Communication.Response;
using Microsoft.AspNetCore.Identity;

namespace GameUsers.API.UseCase.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenService _tokenService;
        public RegisterUserUseCase(UserManager<ApplicationUser> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<AuthResponse> ExecuteAsync(RegisterUserRequest request)
        {
            var user = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email,
                DisplayName = request.DisplayName ?? request.Username
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new DomainException(result.Errors.First().Description);
            }

            var token = _tokenService.CreateToken(user);
            return new AuthResponse(token);
        }
    }
}
