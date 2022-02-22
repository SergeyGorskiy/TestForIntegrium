using Microsoft.EntityFrameworkCore;
using TestForIntegrium.WebApi.Models;

namespace TestForIntegrium.WebApi.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }

        public DbSet<User> Users { get; set; }
    }
}