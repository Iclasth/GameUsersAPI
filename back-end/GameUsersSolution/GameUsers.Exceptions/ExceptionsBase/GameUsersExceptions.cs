using System.Net;

namespace GameUsers.Exceptions.ExceptionsBase
{
    public abstract class GameUsersExceptions : SystemException
    {
        public GameUsersExceptions(string errorMessage) : base(errorMessage)
        {

        }

        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
