namespace GameUsers.Communication.Response
{
    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        public int Id { get; set; }

        public AuthResponse(string token)
        {
            Token = token;
        }
        public AuthResponse(string token, string userName, int id)
        {
            Token = token;
            UserName = userName;
            Id = id;
        }
    }
}
