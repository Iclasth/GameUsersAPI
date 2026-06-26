using GameUsers.API.Models;
using GameUsers.Communication.Request;
using GameUsers.Communication.Response;

namespace GameUsers.API.UseCase.Update
{
    public interface IUpdateUserUseCase
    {
        Task<ResponseShortUserJson> ExecuteAsync(int id, RegisterUserRequest novosDados);
    }
}
