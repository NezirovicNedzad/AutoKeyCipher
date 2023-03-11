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
    public class AdminAutoKeyViewModel : ViewModelBase
    {

       public ICommand AdminListCommand { get;  }

        public ICommand LogoutCommand { get; }
        public AdminAutoKeyViewModel    (NavigationService AdminHomeView,Global global,NavigationService loginViewService,NavigationStore navigationStore,ProfileWindow p,MainWindow m)
        {
         
            AdminListCommand = new NavigateCommand(AdminHomeView);
            LogoutCommand = new LogoutCommand(global, loginViewService, navigationStore, p, m);
        
        }
    }
}
