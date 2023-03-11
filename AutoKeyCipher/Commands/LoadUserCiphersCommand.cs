using AutoKeyCipher.Models;
using AutoKeyCipher.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoKeyCipher.Commands
{
    public class LoadUserCiphersCommand : AsyncCommandBase
    {
        private readonly ListaPretragaViewModel _viewModel;
  
        private readonly Global _global;
    
        public LoadUserCiphersCommand(Global global, ListaPretragaViewModel viewModel)
        {
            _global = global;
            
            _viewModel = viewModel;
           
        }

        public override async  Task ExecuteAsync(object parameter)
        {
            try
            {
                Account a = await _global.GetAccount();
                IEnumerable<Cipher> ciphers = await _global.GetCiphersForUser(a.Email);
                _viewModel.UpdateSearch(ciphers);
               
            }
            catch (Exception)
            {
                MessageBox.Show("Greska pri ucitavanju iy baze", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
