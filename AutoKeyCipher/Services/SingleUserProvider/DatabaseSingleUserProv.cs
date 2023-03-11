using AutoKeyCipher.DbContexts;
using AutoKeyCipher.DTOs;
using AutoKeyCipher.Models;
using AutoKeyCipher.Services.UsersProvider;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.SingleUserProvider
{
    public class DatabaseSingleUserProv : ISingleUserProv
    {

        private readonly AutokeyDbContextFactory _dbContextFactory;

        public DatabaseSingleUserProv(AutokeyDbContextFactory context)
        {
            _dbContextFactory = context;
        }

        public async Task<User> GetSingleUser(string Email)
        {
            using (AutokeyDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<UserDTO> userDTOs = await context.Users.ToListAsync();
                UserDTO user = await context.Users.FirstAsync(us => us.Email == Email);
               
                User _user=ToUser(user);

                return _user; 
            }

            
        }


        private static User ToUser(UserDTO r)
        {
            return new User(r.Name, r.UserName, r.Email, r.Password, r.IsAdmin);
        }
    }
}
