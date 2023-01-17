using AutoKeyCipher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.UserCreator
{
    public interface IUserCreator
    {

        Task CreateUser(User user);
    }
}
