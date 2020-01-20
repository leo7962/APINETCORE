using APINETCORE.Models;
using Microsoft.EntityFrameworkCore;

namespace APINETCORE.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
    }
}
