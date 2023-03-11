using AutoKeyCipher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.LoginAccountCreator
{
    public interface ILoginAccountCreator
    {
        Task CreateAccount(Account account);
    }
}
