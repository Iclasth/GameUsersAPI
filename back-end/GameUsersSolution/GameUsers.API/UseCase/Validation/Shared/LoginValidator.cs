using FluentValidation;
using GameUsers.Communication.Request;

namespace GameUsers.API.UseCase.Validation.Shared
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(login => login.Username)
                .NotEmpty().WithMessage("O nome de usuário é obrigatório.");

            RuleFor(login => login.Password)
                .NotEmpty().WithMessage("A senha é obrigatória.");
                
                
        }
    }
}
