using AutoKeyCipher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.LoginAccountProvider
{
    public interface ILoginAccountProvider
    {

        Task<Account> GetSingleAccount();

    }
}
