using GameUsers.API.Models;
using GameUsers.API.Services;
using GameUsers.Communication.Response;
using GameUsers.Exceptions.ExceptionsBase;
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
        public async Task<ResponseShortUserJson> ExecuteAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null) throw new NotFoundException("O usuário em questão não foi encontrado.");

            var token = _tokenService.CreateToken(user);

            return new ResponseShortUserJson
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Token = token,
            };
        }
    }
}
