namespace GameUsers.Communication.Response
{
    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;

        public AuthResponse(string token)
        {
            Token = token;
        }
    }
}
