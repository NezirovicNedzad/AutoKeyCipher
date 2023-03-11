using AutoKeyCipher.Commands;
using AutoKeyCipher.Models;
using AutoKeyCipher.Services;
using AutoKeyCipher.Stores;
using AutoKeyCipher.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoKeyCipher.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {

        private readonly ObservableCollection<Cipher> _ciphers;


        public IEnumerable<Cipher> Ciphers => _ciphers;
        public ICommand LoadCiphers{ get; }
        

        public ICommand LogoutCommand { get; }
        public ICommand AutoKeyCommand { get; }

        public AdminViewModel(Global global,NavigationService AutokeyNavService, NavigationService loginNavService,NavigationStore store,ProfileWindow W,MainWindow m)
        {

            _ciphers = new ObservableCollection<Cipher>();

            LoadCiphers = new LoadCiphers(this,global);
            LogoutCommand = new LogoutCommand(global, loginNavService, store, W, m);
           
            AutoKeyCommand = new NavigateCommand(AutokeyNavService);
        }




        public static AdminViewModel LoadAllCiphers(Global global, NavigationService AutokeyNavService, NavigationService loginNavService, NavigationStore store, ProfileWindow W, MainWindow m) {
            AdminViewModel viewModel = new AdminViewModel(global,AutokeyNavService,loginNavService,store,W,m);

            viewModel.LoadCiphers.Execute(null);


            return viewModel;


        }

        public void UpdateCiphers(IEnumerable<Cipher> ciphers)
        {





            foreach (Cipher cipher in ciphers)
            {
                Cipher allUserListingViewModel = new Cipher(cipher.Guid, cipher.Email, cipher.Keystream, cipher.Text, cipher.Coded);
                _ciphers.Add(allUserListingViewModel);
            }
        }
    }
}
