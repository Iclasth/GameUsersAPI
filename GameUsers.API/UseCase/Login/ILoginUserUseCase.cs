using GameUsers.Communication.Request;
using GameUsers.Communication.Response;

namespace GameUsers.API.UseCase.Login
{
    public interface ILoginUserUseCase
    {
        Task<AuthResponse> ExecuteAsync(LoginUserRequest request);
    }
}
