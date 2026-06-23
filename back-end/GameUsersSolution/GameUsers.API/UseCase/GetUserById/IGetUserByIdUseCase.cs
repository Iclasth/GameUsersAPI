using GameUsers.Communication.Request;
using GameUsers.Communication.Response;

namespace GameUsers.API.UseCase.GetUserById
{
    public interface IGetUserByIdUseCase
    {
        Task<AuthResponse> ExecuteAsync(int id);
    }
}
