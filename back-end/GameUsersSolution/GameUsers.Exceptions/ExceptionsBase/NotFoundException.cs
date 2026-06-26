using System.Net;

namespace GameUsers.Exceptions.ExceptionsBase
{
    public class NotFoundException : GameUsersExceptions
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {
        }

        public override List<string> GetErrors() => [Message];
        

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
       
    }
}
