using GameUsers.API.Models;
using GameUsers.API.Services;
using GameUsers.API.UseCase.Validation;
using GameUsers.Communication.Request;
using GameUsers.Communication.Response;
using GameUsers.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Identity;

namespace GameUsers.API.UseCase.Update
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenService _tokenService;
        public UpdateUserUseCase(UserManager<ApplicationUser> userManager, TokenService tokenService) 
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<AuthResponse> ExecuteAsync(int id, RegisterUserRequest novosDados)
        {
            Validate(novosDados);

            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null) return null;

            var update = await _userManager.UpdateAsync(user);

            var token = _tokenService.CreateToken(user);

            return new AuthResponse(token, user.UserName, user.Id);
        }

        private void Validate(RegisterUserRequest request)
        {
            var validator = new RegisterUserRequestValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
