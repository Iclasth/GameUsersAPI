using System.Net;

namespace GameUsers.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : GameUsersExceptions
    {
        private readonly List<string> _errors;

        public ErrorOnValidationException(List<string> errorMesages) : base(string.Empty)
        {
            _errors = errorMesages;
        }

        public override List<string> GetErrors() => _errors;

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;


    }
}
