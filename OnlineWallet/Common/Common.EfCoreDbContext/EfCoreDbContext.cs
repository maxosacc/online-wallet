using Microsoft.EntityFrameworkCore;

namespace Common.EfCoreDbContext
{
    public class EfCoreDbContext : DbContext
    {
        public EfCoreDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
