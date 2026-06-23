using GameUsers.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GameUsers.API.Infraestructure
{
    public class GameUsersDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public GameUsersDbContext(DbContextOptions<GameUsersDbContext> options) : base(options)
        {

        }

        

    }
}
