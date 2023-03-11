using AutoKeyCipher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.CipherProvider
{
    public interface ICipherProvider
    {
        Task<IEnumerable<Cipher>> GetAllCiphers();
    }
}
