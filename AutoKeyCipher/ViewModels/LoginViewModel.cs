using AutoKeyCipher.Commands;
using AutoKeyCipher.Models;
using AutoKeyCipher.Services;
using AutoKeyCipher.Stores;
using AutoKeyCipher.Views;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoKeyCipher.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {


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


        public string _password;
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

       



        public string _errorMessage;
        public string ErrorMessage
        {


            get
            {
                return _errorMessage;
            }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }
        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);



        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }


       
        public void ShowWindow()
        { 
        }
        public LoginViewModel(Global _global, NavigationService registrationViewNavigationService,NavigationService allListingViewNavService, NavigationService adminNavService, NavigationStore _navigationStore,ProfileWindow p)
        {
            
            RegisterCommand = new NavigateCommand(registrationViewNavigationService);

            LoginCommand = new LoginCommand(this, _global,allListingViewNavService,_navigationStore,p,adminNavService);


           
        }
    }
}
