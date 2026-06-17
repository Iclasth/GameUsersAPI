using GameUsers.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GameUsers.API.Infraestructure
{
    public class GameUsersDbContext : IdentityDbContext<ApplicationUser>
    {
        public GameUsersDbContext(DbContextOptions<GameUsersDbContext> options) : base(options)
        {

        }

        

    }
}
