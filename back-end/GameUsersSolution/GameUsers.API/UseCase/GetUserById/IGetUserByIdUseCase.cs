using GameUsers.Communication.Request;
using GameUsers.Communication.Response;

namespace GameUsers.API.UseCase.GetUserById
{
    public interface IGetUserByIdUseCase
    {
        Task<ResponseShortUserJson> ExecuteAsync(int id);
    }
}
