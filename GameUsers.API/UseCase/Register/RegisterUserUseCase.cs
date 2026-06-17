using GameUsers.API.Models;
using GameUsers.API.Services;
using GameUsers.API.UseCase.Validation;
using GameUsers.Communication.Request;
using GameUsers.Communication.Response;
using GameUsers.Exceptions.ExceptionsBase;
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
            // Executa a validação dos dados de entrada
            Validate(request);

            var userExists = await _userManager.FindByNameAsync(request.Username);
            if(userExists != null)
            {
                throw new Exception("User already exist");
            }

            var user = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email,
                DisplayName = request.DisplayName ?? request.Username
            };

            var result = await _userManager.CreateAsync(user, request.Password);

           

            var token = _tokenService.CreateToken(user);
            return new AuthResponse(token);
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
