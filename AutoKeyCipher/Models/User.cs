using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Models
{
    public class User :DomainObjectId
    {


       

       
     
        public string Name { get; set; }    


        public string UserName { get; set; }
        public string Email { get; set;  }
        public string Password { get; set; }

        public bool IsAdmin { get; set; }    

   
        public User(string name, string userName, string email, string password,bool isAdmin)
        {
            Name = name;
            UserName = userName;
            Email = email;
            Password = password;
          IsAdmin = isAdmin;    
        }
        public void SetUserEmail(string email)
        {
            Email = email;
        }



     


     
    }
}
