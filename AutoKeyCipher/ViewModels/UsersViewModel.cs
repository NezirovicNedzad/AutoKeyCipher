using AutoKeyCipher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.ViewModels
{
    public class UsersViewModel :ViewModelBase
    {
        private readonly User _user;

        //Ne zelimo kontakt sa User Modelom iz ViewModela jer nam to kvari MVVM pattern jer On Notify
        //Property change komunicira sa modelima zbog toga i ova pomocna klasa

        public string Name =>_user.Name;    


        public string UserName =>_user.UserName.ToString();
        public string Email=>_user.Email.ToString();
        public string Password =>_user.Password.ToString();


        public UsersViewModel(User user)
        {
            _user = user;
        }


    }
}
