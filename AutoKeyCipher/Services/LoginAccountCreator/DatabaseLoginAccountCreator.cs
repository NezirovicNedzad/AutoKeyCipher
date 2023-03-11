using AutoKeyCipher.DbContexts;
using AutoKeyCipher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.LoginAccountCreator
{
    public class DatabaseLoginAccountCreator : ILoginAccountCreator
    {

        private readonly AutokeyDbContextFactory _dbContextFactory;

        public DatabaseLoginAccountCreator(AutokeyDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateAccount(Account account)
        {
            using (AutokeyDbContext context = _dbContextFactory.CreateDbContext())
            {

                context.Accounts.Add(account);
                await context.SaveChangesAsync();

            }
        }
    }
}
