using AutoKeyCipher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.UsersProvider
{
    public interface IUserProvider 
    {


        Task<IEnumerable<User>> GetAllUsers();
    }
}
