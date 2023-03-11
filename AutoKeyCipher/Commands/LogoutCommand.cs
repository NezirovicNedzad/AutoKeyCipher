using AutoKeyCipher.Models;
using AutoKeyCipher.Services;
using AutoKeyCipher.Stores;
using AutoKeyCipher.ViewModels;
using AutoKeyCipher.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Commands
{
    public class LogoutCommand : AsyncCommandBase
    {



        private readonly Global _global;
        
        private NavigationService _loginViewModelNavigationService;
        private NavigationStore _navigationStore;
        private ProfileWindow _profileWindow;
        private MainWindow _mainWindow;
        public LogoutCommand(Global global, NavigationService loginViewModelNavigationService, NavigationStore navigationStore, ProfileWindow profileWindow, MainWindow mainWindow)
        {
            _global = global;
            _loginViewModelNavigationService = loginViewModelNavigationService;
            _navigationStore = navigationStore;
            _profileWindow = profileWindow;
            _mainWindow = mainWindow;
        }

        public async override Task ExecuteAsync(object parameter)
        {
             await _global.DeleteAccounts();
            _profileWindow.Close();

            _loginViewModelNavigationService.Navigate();

          


            _mainWindow.Show();
        }
    }
}
