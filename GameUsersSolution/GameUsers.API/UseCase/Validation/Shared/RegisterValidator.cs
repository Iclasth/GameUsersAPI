using FluentValidation;
using GameUsers.Communication.Request;

namespace GameUsers.API.UseCase.Validation.Shared
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(4).WithMessage("Username must be at least 4 characters long.")
                .MaximumLength(26).WithMessage("Username must not exceed 26 characters.");
            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
                .MaximumLength(100).WithMessage("Password must not exceed 100 characters.")
                .Matches("[A-Z]").WithMessage("The Passwor must contain an Uppercase letter.")
                .Matches("[a-z]").WithMessage("The Password must contain a lowercase letter")
                .Matches("[0-9]").WithMessage("The Password must contain a number");
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email address is required.");
        }
    }
}
