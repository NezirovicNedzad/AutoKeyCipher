using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Models
{
    public class User :DomainObjectId
    {


       

       
     
        public string Name { get;  }    


        public string UserName { get;  }
        public string Email { get;  }
        public string Password { get; }


        public User(string name, string userName, string email, string password)
        {
            Name = name;
            UserName = userName;
            Email = email;
            Password = password;
        }



     


     
    }
}
