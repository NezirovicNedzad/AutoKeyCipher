using AutoKeyCipher.Commands;
using AutoKeyCipher.Models;
using AutoKeyCipher.Services;
using AutoKeyCipher.Stores;
using AutoKeyCipher.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoKeyCipher.ViewModels
{
    public class AutoKeyViewModel : ViewModelBase
    {

        public ICommand HomeCommand { get; }
        public ICommand ListCommand { get; }
        public ICommand LogoutCommand { get; }
        public AutoKeyViewModel(NavigationService HomeViewService,NavigationService ListViewService,Global global,NavigationService loginNavService,NavigationStore store, ProfileWindow p,MainWindow m )
        {

            HomeCommand = new NavigateCommand(HomeViewService);
            ListCommand = new NavigateCommand(ListViewService);
            LogoutCommand = new LogoutCommand(global, loginNavService, store, p, m);
        }
    }
}
