using AutoKeyCipher.DbContexts;
using AutoKeyCipher.DTOs;
using AutoKeyCipher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.CipherCreator
{
    public class DatabaseCipherCreate :ICipherCreator
    {
        private readonly AutokeyDbContextFactory _dbContextFactory;

        public DatabaseCipherCreate(AutokeyDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateCipher(Cipher cipher)
        {
            using (AutokeyDbContext context = _dbContextFactory.CreateDbContext())
            {
               

                context.Ciphers.Add(cipher);
                await context.SaveChangesAsync();
            }
        }
    }
}
