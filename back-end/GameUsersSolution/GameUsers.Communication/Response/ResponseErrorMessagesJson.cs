namespace GameUsers.Communication.Response
{
    public class ResponseErrorMessagesJson
    {
        public List<string> ErrorsMessages { get; private set; }

        public ResponseErrorMessagesJson(string message)
        {
            ErrorsMessages = [message];
        }

        public ResponseErrorMessagesJson(List<string> messages) 
        {
            ErrorsMessages = messages;
        }
    }
}
