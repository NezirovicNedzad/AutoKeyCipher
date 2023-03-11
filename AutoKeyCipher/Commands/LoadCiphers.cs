using AutoKeyCipher.Models;
using AutoKeyCipher.ViewModels;
using AutoKeyCipher.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoKeyCipher.Commands
{
    public class LoadCiphers : AsyncCommandBase
    {
        private readonly AdminViewModel _viewModel;
          private readonly Global _global;

        public LoadCiphers(AdminViewModel viewModel, Global global)
        {
            _viewModel = viewModel;
            _global = global;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Cipher> ciphers = await _global.GetAllC();
            _viewModel.UpdateCiphers
                    (ciphers);  

            }
            catch (Exception)
            {
                MessageBox.Show("Greska pri ucitavanju iy baze", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
