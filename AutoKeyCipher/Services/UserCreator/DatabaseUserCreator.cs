using AutoKeyCipher.DbContexts;
using AutoKeyCipher.DTOs;
using AutoKeyCipher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.UserCreator
{
    public class DatabaseUserCreator : IUserCreator
    {

        private readonly AutokeyDbContextFactory _dbContextFactory;

        public DatabaseUserCreator(AutokeyDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateUser(User user)
        {
            using (AutokeyDbContext context=_dbContextFactory.CreateDbContext())
            {
                UserDTO userDTO = ToUserDTO(user);

                context.Users.Add(userDTO); 
               await  context.SaveChangesAsync();
            }
        }

        private UserDTO ToUserDTO(User user)
        {
            return new UserDTO()
            {
                Name = user.Name,
                UserName = user.UserName,   
                Email = user.Email, 
                Password = user.Password
                
            };
         
                
        }
    }
}
