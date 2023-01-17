using AutoKeyCipher.DbContexts;
using AutoKeyCipher.DTOs;
using AutoKeyCipher.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.UsersProvider
{
    public class DatabaseUsersProvider : IUserProvider
    {
        private readonly AutokeyDbContextFactory _dbContextFactory;

        public DatabaseUsersProvider(AutokeyDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            using (AutokeyDbContext context = _dbContextFactory.CreateDbContext())
            {

                IEnumerable<UserDTO> userDTOs = await context.Users.ToListAsync();


                return userDTOs.Select(r => ToUser(r));

            }
        }

        private static User ToUser(UserDTO r)
        {
            return new User(r.Name, r.UserName, r.Email, r.Password);
        }
    }
}
