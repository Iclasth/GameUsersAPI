namespace GameUsers.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string DisplayName { get; set; } = string.Empty;

        public string Class { get; set; } = string.Empty;
        public int Level { get; set; }


    }
}
