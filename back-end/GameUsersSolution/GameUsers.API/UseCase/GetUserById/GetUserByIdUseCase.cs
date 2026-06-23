using GameUsers.API.Models;
using GameUsers.API.Services;
using GameUsers.Communication.Response;
using Microsoft.AspNetCore.Identity;

namespace GameUsers.API.UseCase.GetUserById
{
    public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenService _tokenService;
        public GetUserByIdUseCase(UserManager<ApplicationUser> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<AuthResponse?> ExecuteAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null) return null;

            var token = _tokenService.CreateToken(user);

            return new AuthResponse(token, user.UserName, user.Id);
        }
    }
}
