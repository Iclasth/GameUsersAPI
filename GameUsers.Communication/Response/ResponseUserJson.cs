namespace GameUsers.Communication.Response
{
    public class ResponseUserJson
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
       
        public string DisplayName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } 
    }
}
