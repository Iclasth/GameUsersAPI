using GameUsers.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameUsers.API.Infraestructure
{
    public class GameUsersDbContext : DbContext
    {
        public DbSet<User> Users {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Banco de Dados\\Entity Framework\\GameUsersAPIEF\\gameusers.db");
        }
    }
}
