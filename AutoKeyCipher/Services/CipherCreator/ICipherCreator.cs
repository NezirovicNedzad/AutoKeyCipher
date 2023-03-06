using AutoKeyCipher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Services.CipherCreator
{
    public interface ICipherCreator
    {

        Task CreateCipher(Cipher cipher);
    }
}
