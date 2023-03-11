using AutoKeyCipher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.CipherUserProvider
{
    public interface ICipherUserProvider
    {


        Task<IEnumerable<Cipher>> GetCiphers(string Email);
    }
}
