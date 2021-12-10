using Coodesh.SpaceFlightNews.DTO;
using Microsoft.EntityFrameworkCore;
namespace Coodesh.SpaceFlightNews.Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Launch> Launches { get; set; }

    }
}
