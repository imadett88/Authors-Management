using Microsoft.EntityFrameworkCore;
using Post.Domain.Entity;

namespace Post.Infrastructure.Data
{
    public class AuthorDbContext : DbContext
    {
        public AuthorDbContext(DbContextOptions<AuthorDbContext> options) : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
    }
}
