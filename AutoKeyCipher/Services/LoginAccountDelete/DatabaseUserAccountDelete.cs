using AutoKeyCipher.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.LoginAccountDelete
{
    public class DatabaseUserAccountDelete : ILoginAccountDelete
    {


        private readonly AutokeyDbContextFactory _dbContextFactory;

        public DatabaseUserAccountDelete(AutokeyDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task DeleteUserAcc()
        {
            using (AutokeyDbContext context = _dbContextFactory.CreateDbContext())
            {



                context.Accounts.RemoveRange(context.Accounts);


                await context.SaveChangesAsync();
            }
        }
    }
}
