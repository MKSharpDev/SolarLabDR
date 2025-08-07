using Microsoft.EntityFrameworkCore;
using SolarLabDR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.Migrator
{
    public class MigrationDbContext : DrDbContext
    {
        public MigrationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
