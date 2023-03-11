using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Models
{
    public  class Cipher
    {
        [Key]
       public Guid Guid { get; set; } 
        public string Email { get; set; }


        public string Keystream { get; set; }


        public string Text { get; set; }

        public string Coded { get; set; }


        public Cipher(Guid guid, string email, string keystream, string text, string coded)
        {
            Guid = guid;
            Email = email;
            Keystream = keystream;
            Text = text;
            Coded = coded;


        }
    }
}
