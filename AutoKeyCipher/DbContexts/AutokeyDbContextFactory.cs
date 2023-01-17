using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.DbContexts
{
    public class AutokeyDbContextFactory
    {

        private readonly string _connectionString;

        public AutokeyDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AutokeyDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options;



            return new AutokeyDbContext(options);

        }
    }
}
