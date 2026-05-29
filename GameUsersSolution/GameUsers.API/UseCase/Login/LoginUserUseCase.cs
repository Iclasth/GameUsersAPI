using GameUsers.API.Models;
using GameUsers.API.Services;
using GameUsers.API.UseCase.Validation;
using GameUsers.Communication.Request;
using GameUsers.Communication.Response;
using GameUsers.Exceptions.ExceptionsBase;
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
            var user = await _userManager.FindByNameAsync(request.Username) ?? throw new Exception("Invalid credentials.");

            var validPassword = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);

            if (!validPassword.Succeeded)
            {
                throw new Exception("Invalid Password.");
            }

            var token = _tokenService.CreateToken(user);

            return new AuthResponse(token);

        }

        private void Validate(LoginUserRequest request)
        {
            var validator = new LoginUserRequestValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
