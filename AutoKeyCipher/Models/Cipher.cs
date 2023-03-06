using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Models
{
    public  class Cipher
    {

        public Guid Id { get; set; }


        public string Keystream { get; set; }


        public string Text { get; set; }

        public string Coded { get; set; }


        public Cipher(Guid id, string keystream, string text, string coded)
        {
            Id=id;
            Keystream = keystream;
            Text = text;
            Coded = coded;  
        }

    }
}
