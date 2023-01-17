using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.DbContexts
{
    internal class AutoKeyDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AutokeyDbContext>
    {
        public AutokeyDbContext CreateDbContext(string[] args)
        {
           DbContextOptions options= new DbContextOptionsBuilder().UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AutoKeyCipher;Trusted_Connection=True;").Options;



            return new AutokeyDbContext(options);
           
        }
    }
}
