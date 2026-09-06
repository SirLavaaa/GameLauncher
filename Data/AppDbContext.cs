using Microsoft.EntityFrameworkCore;
using GameLauncher.Models;

namespace GameLauncher.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

        public DbSet<Game> Games {get; set;} = null;
    }
}
