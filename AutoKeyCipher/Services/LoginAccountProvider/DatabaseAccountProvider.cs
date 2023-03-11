using AutoKeyCipher.DbContexts;
using AutoKeyCipher.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.LoginAccountProvider
{
    public class DatabaseAccountProvider : ILoginAccountProvider
    {
        private readonly AutokeyDbContextFactory _dbContextFactory;

        public DatabaseAccountProvider(AutokeyDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Account> GetSingleAccount()
        {
            using(AutokeyDbContext context=_dbContextFactory.CreateDbContext()) {

               Account a= await context.Accounts.FirstAsync();

                return a;
            }
        }
    }
}
