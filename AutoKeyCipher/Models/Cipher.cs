using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Models
{
    public  class Cipher
    {

        public User Sifrer { get; }


        public string Keystream { get; }


        public string Text { get; }

        public string Coded { get; }


        public Cipher(User sifrer, string keystream, string text, string coded)
        {
            Sifrer = sifrer;
            Keystream = keystream;
            Text = text;
            Coded = coded;  
        }

    }
}
