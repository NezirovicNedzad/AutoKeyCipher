using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Stores
{
    public class LoginStore
    {
        public string Password { get; set; }    
        public string Email { get; set; }

       
        public LoginStore(string password, string email)
        {
            Password = password;
            Email = email;
        }
    }
}
