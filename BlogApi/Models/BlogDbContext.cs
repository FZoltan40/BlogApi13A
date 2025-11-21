using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BlogApi.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext()
        {

        }

        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blogger> bloggers { get; set; }
        public DbSet<Post> posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=blog13a;user=root;password=");
        }
    }
}
