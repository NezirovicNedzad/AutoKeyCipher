using AutoKeyCipher.DbContexts;
using AutoKeyCipher.Models;
using AutoKeyCipher.Services;
using AutoKeyCipher.Services.UserCreator;
using AutoKeyCipher.Services.UsersProvider;
using AutoKeyCipher.Stores;
using AutoKeyCipher.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AutoKeyCipher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly Global _global;
        private readonly NavigationStore _navigationStore;
        private readonly AutokeyDbContextFactory _autokeyDbContextFactory;    
        private readonly string connection_string = "Server=localhost\\SQLEXPRESS;Database=AutoKeyCipher;Trusted_Connection=True;";
        public App()
        {

           _autokeyDbContextFactory = new AutokeyDbContextFactory(connection_string);

            IUserProvider userProvider = new DatabaseUsersProvider(_autokeyDbContextFactory);
            IUserCreator userCreator = new DatabaseUserCreator(_autokeyDbContextFactory);
            _global = new Global(userProvider,userCreator);
            _navigationStore = new NavigationStore();
        }



        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(connection_string).Options;
            using (AutokeyDbContext dbContext = _autokeyDbContextFactory.CreateDbContext()) 
            {

                dbContext.Database.Migrate();
            }

   



            _navigationStore.CurrentViewModel = CreateLoginViewModel();   

          


            MainWindow = new MainWindow()
            {


                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }


        private MakeRegistrationViewModel CreateRegistrationViewModel()
        {


            return new MakeRegistrationViewModel(_global,new NavigationService(_navigationStore, CreateLoginViewModel), new NavigationService(_navigationStore, CreateLoginViewModel));
        }


        private AllUsersListingViewModel CreateReservationViewModel()
        {
            return  AllUsersListingViewModel.LoadViewModel(_global, new NavigationService(_navigationStore, CreateRegistrationViewModel));
        }

        private LoginViewModel CreateLoginViewModel()
        {


            return new LoginViewModel(_global,new NavigationService(_navigationStore,CreateRegistrationViewModel), new NavigationService(_navigationStore, CreateProfileViewModel));
        }
        private ProfilePageViewModel CreateProfileViewModel()
        {


            return new ProfilePageViewModel(new NavigationService(_navigationStore,CreateListPretragaViewModel));
        }
        private ListaPretragaViewModel CreateListPretragaViewModel()
        {


            return new ListaPretragaViewModel();
        }
    }
}
