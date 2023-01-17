using AutoKeyCipher.Commands;
using AutoKeyCipher.Models;
using AutoKeyCipher.Services;
using AutoKeyCipher.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoKeyCipher.ViewModels
{
    public class MakeRegistrationViewModel : ViewModelBase  
    {

        private string _name;



        public string Name
        {


            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _email;



        public string Email
        {


            get
            {
                return _email;
            }

            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _username;



        public string Username
        {


            get
            {
                return _username;
            }

            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }


        private string _password;



        public string Password
        {


            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


        public ICommand SubmitCommand { get; }
        public ICommand SwitchtoLoginCommand { get; }
        

        public MakeRegistrationViewModel(Global _global,NavigationService registrationViewNavigationService,NavigationService loginNavigationService)
        {



            SubmitCommand = new MakeRegistrationCommand(this, _global,registrationViewNavigationService); 
            SwitchtoLoginCommand=new NavigateCommand(loginNavigationService);
        
        
        
        }



    }
}
