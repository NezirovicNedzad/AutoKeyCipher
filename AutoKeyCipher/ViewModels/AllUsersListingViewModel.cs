using AutoKeyCipher.Commands;
using AutoKeyCipher.Models;
using AutoKeyCipher.Services;
using AutoKeyCipher.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoKeyCipher.ViewModels
{
    public class AllUsersListingViewModel:ViewModelBase
    {
        private readonly Global _global;
        private readonly ObservableCollection<UsersViewModel> _users;

        public IEnumerable<UsersViewModel> Users => _users;

        public ICommand MakeRegistrationCommand { get; }

        public ICommand LoadUsersCommand { get; }
        public AllUsersListingViewModel(Global global, NavigationService makeRegistrationNavigationService)
        {
            _global = global;
            _users = new ObservableCollection<UsersViewModel>();
            MakeRegistrationCommand = new NavigateCommand(makeRegistrationNavigationService);
            LoadUsersCommand = new LoadUsersCommand(this, global);

          
        }

        public static AllUsersListingViewModel LoadViewModel(Global global,NavigationService makeRegistrationNavigationService)
        {

            AllUsersListingViewModel viewModel = new AllUsersListingViewModel(global, makeRegistrationNavigationService);

            viewModel.LoadUsersCommand.Execute(null);
         

            return viewModel;
        
        }



        public void UpdateRegistrations(IEnumerable<User> users)
        {
            _users.Clear();


            foreach (User user in users)
            {
                UsersViewModel allUserListingViewModel = new UsersViewModel(user);
                _users.Add(allUserListingViewModel);    
            }
        }
    }
}
