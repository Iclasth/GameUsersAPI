using FluentValidation;
using GameUsers.Communication.Request;

namespace GameUsers.API.UseCase.Validation.Shared
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
    }
}
