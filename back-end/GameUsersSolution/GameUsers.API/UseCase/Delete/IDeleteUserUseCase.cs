using GameUsers.Communication.Response;

namespace GameUsers.API.UseCase.Delete
{
    public interface IDeleteUserUseCase
    {
        Task<AuthResponse> ExecuteAsync(int id);
    }
}
