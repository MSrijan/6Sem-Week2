using Microsoft.EntityFrameworkCore;
using Week2.Entities;

namespace Week2.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
