using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Models
{
    public class Account : DomainObjectId

    {
        

        public string Email { get; set; }
        public string Password { get; set; }

        public Account(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
