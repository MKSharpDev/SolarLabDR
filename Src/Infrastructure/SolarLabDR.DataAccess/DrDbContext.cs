using Microsoft.EntityFrameworkCore;
using SolarLabDR.DataAccess.Configuration;

namespace SolarLabDR.DataAccess
{
    public class DrDbContext : DbContext
    {
        public DrDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
