using AutoKeyCipher.DbContexts;
using AutoKeyCipher.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.CipherUserProvider
{
    public class DatabaseCipherUserProvider : ICipherUserProvider
    {
        private readonly AutokeyDbContextFactory _contextFactory;

        public DatabaseCipherUserProvider(AutokeyDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Cipher>> GetCiphers(string Email)
        {
            using(AutokeyDbContext context = _contextFactory.CreateDbContext())
            {
            IEnumerable<Cipher> ciphers=await context.Ciphers.ToListAsync();

                IEnumerable<Cipher> result= ciphers.Where(c => c.Email == Email);   

                return result;


            }
        }
    }
}
