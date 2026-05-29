using Microsoft.AspNetCore.Identity;

namespace GameUsers.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;

        public int Level { get; set; } = 1;
    }
}
