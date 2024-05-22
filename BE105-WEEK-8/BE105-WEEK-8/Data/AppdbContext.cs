using BE105_WEEK_8.Entities;
using Microsoft.EntityFrameworkCore;

namespace BE105_WEEK_8.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
