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
    public class LoadUsersCommand : AsyncCommandBase
    {
        private readonly AllUsersListingViewModel _viewModel;
        private readonly Global _global;

        public LoadUsersCommand(AllUsersListingViewModel viewModel, Global global)
        {
            _viewModel = viewModel;
            _global = global;
        }

        public override async Task ExecuteAsync(object parameter)
        {

            try
            {
                IEnumerable<User> users = await _global.GetAllUsers();


                _viewModel.UpdateRegistrations(users);
            }
            catch (Exception)
            {
                MessageBox.Show("Greska pri ucitavanju iy baze", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }
    }
}
