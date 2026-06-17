using GameUsers.Communication.Request;
using GameUsers.Communication.Response;

namespace GameUsers.API.UseCase.Register
{
    public interface IRegisterUserUseCase
    {
        Task<AuthResponse> ExecuteAsync(RegisterUserRequest request);
    }
}
