using AutoKeyCipher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.ViewModels
{
     public class CipherViewModel : ViewModelBase   
    {

        private readonly Cipher _cipher;

       

        //Ne zelimo kontakt sa User Modelom iz ViewModela jer nam to kvari MVVM pattern jer On Notify
        //Property change komunicira sa modelima zbog toga i ova pomocna klasa
        public string Email => _cipher.Email.ToString();   


        public string Keystream =>_cipher.Keystream.ToString();

        public string Text => _cipher.Text.ToString();

        public string Coded => _cipher.Coded.ToString() ;


        public CipherViewModel(Cipher cipher)
        {
            _cipher = cipher;
        }

    }
}
