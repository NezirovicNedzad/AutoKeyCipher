using AutoKeyCipher.Commands;
using AutoKeyCipher.Models;
using AutoKeyCipher.Services;
using AutoKeyCipher.Stores;
using AutoKeyCipher.Views;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutoKeyCipher.ViewModels
{
    public class ProfilePageViewModel : ViewModelBase
    {

      
        Action CloseAction { get; set; }


        public ICommand ListCommand { get; }
        public ICommand StartDecodingCommand { get; }
        public ICommand AddCipherCommand { get; }

     


        public ICommand LogoutCommand { get; }

        public ICommand AutoKeyCommand { get; }



        public ProfilePageViewModel(NavigationService allListingViewNavigationService, NavigationService LoginViewModelNavigationService, NavigationService AutoKeyViewNavigationService, Global global, NavigationStore navigationStore,ProfileWindow profileWindow,MainWindow main)


        {
            StartDecodingCommand = new StartDecodingCommand(this);
            ListCommand = new NavigateCommand(allListingViewNavigationService);
            AddCipherCommand = new AddCipherCommand(global, this);
            AutoKeyCommand = new NavigateCommand(AutoKeyViewNavigationService);
            LogoutCommand = new LogoutCommand(global, LoginViewModelNavigationService,navigationStore,profileWindow,main);
            
        }

        private string _plaintext;



 

        public string Plaintext
        {


            get
            {
                return _plaintext;
            }

            set
            {
                _plaintext = value;
                OnPropertyChanged(nameof(Plaintext));
            }
        }


        private string _plaintextUpper;





        public string PlaintextUpper
        {


            get
            {
                return _plaintextUpper;
            }

            set
            {
                _plaintextUpper = value;
                OnPropertyChanged(nameof(PlaintextUpper));
            }
        }

        private string _coded;





        public string Coded
        {


            get
            {
                return _coded;
            }

            set
            {
                _coded = value;
                OnPropertyChanged(nameof(Coded));
            }
        }


        public string _key;

        public string Key   
        {


            get
            {
                return _key;
            }

            set
            {
                _key = value;
                OnPropertyChanged(nameof(Key));
            }
        }
        public string _autokey;

        public string AutoKey
        {


            get
            {
                return _autokey;
            }

            set
            {
                _autokey = value;
                OnPropertyChanged(nameof(AutoKey));
            }
        }



         
      
        


    }
}
