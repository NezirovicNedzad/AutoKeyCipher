using AutoKeyCipher.Commands;
using AutoKeyCipher.Models;
using AutoKeyCipher.Services;
using AutoKeyCipher.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace AutoKeyCipher.ViewModels
{
    public class ListaPretragaViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Cipher> _ciphers;

      
        public IEnumerable<Cipher> Ciphers => _ciphers;
        public ICommand LoadCipherForUser { get; }


     
        public ICommand HomeCommand { get; }
        public ICommand AutoKeyCommand { get; }

       
        public ListaPretragaViewModel(Global global, Services.NavigationService HomeViewNavigationService, Services.NavigationService autokeyView)
        {

            _ciphers = new ObservableCollection<Cipher>();
          
            LoadCipherForUser = new LoadUserCiphersCommand(global,this);
            HomeCommand=new NavigateCommand(HomeViewNavigationService);
            AutoKeyCommand = new NavigateCommand(autokeyView);

        }

        public static  ListaPretragaViewModel LoadViewModel(Global global,  Services.NavigationService HomeViewNavigationService, Services.NavigationService autokeyView)
        {

        
                ListaPretragaViewModel viewModel = new ListaPretragaViewModel(global,HomeViewNavigationService,autokeyView);

            viewModel.LoadCipherForUser.Execute(null);


            return viewModel;

        }


        public void UpdateSearch(IEnumerable<Cipher> ciphers)
        {
           

              


            foreach (Cipher cipher in ciphers)
            {
                Cipher allUserListingViewModel = new Cipher(cipher.Guid,cipher.Email,cipher.Keystream,cipher.Text,cipher.Coded);
                _ciphers.Add(allUserListingViewModel);
            }
        }
    }
}
