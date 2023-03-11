using AutoKeyCipher.DbContexts;
using AutoKeyCipher.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.CipherProvider
{
    public class DatabaseCipherProvider : ICipherProvider
    {
        private readonly AutokeyDbContextFactory _dbContextFactory;

        public DatabaseCipherProvider(AutokeyDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Cipher>> GetAllCiphers()
        {
            using(AutokeyDbContext context=_dbContextFactory.CreateDbContext()) {

                IEnumerable<Cipher> ciphers = await context.Ciphers.ToListAsync();
            

                return ciphers; 
            }
        }
    }
}
