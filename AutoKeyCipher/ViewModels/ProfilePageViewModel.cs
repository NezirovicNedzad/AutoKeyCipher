using AutoKeyCipher.Commands;
using AutoKeyCipher.Models;
using AutoKeyCipher.Services;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutoKeyCipher.ViewModels
{
    public class ProfilePageViewModel : ViewModelBase
    {

 

        public ICommand ListCommand { get; }
        public ICommand StartDecodingCommand { get; }



        
       

      

        public ProfilePageViewModel(NavigationService allListingViewNavigationService)


        {
            StartDecodingCommand=new StartDecodingCommand(this);
            ListCommand = new  NavigateCommand(allListingViewNavigationService);
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
