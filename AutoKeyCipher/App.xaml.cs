using AutoKeyCipher.DbContexts;
using AutoKeyCipher.Models;
using AutoKeyCipher.Services;
using AutoKeyCipher.Services.CipherCreator;
using AutoKeyCipher.Services.CipherProvider;
using AutoKeyCipher.Services.CipherUserProvider;
using AutoKeyCipher.Services.LoginAccountCreator;
using AutoKeyCipher.Services.LoginAccountDelete;
using AutoKeyCipher.Services.LoginAccountProvider;
using AutoKeyCipher.Services.SingleUserProvider;
using AutoKeyCipher.Services.UserCreator;
using AutoKeyCipher.Services.UsersProvider;
using AutoKeyCipher.Stores;
using AutoKeyCipher.ViewModels;
using AutoKeyCipher.Views;
using Microsoft.EntityFrameworkCore;
using Prism.Ioc;
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
        public ProfileWindow p;
        public MainWindow m;

        public int count = 1;
        private readonly string connection_string = "Server=localhost\\SQLEXPRESS;Database=AutoKeyCipher;Trusted_Connection=True;";
        public App()
        {

            _autokeyDbContextFactory = new AutokeyDbContextFactory(connection_string);

            IUserProvider userProvider = new DatabaseUsersProvider(_autokeyDbContextFactory);
            ILoginAccountCreator loginAccountCreator = new DatabaseLoginAccountCreator(_autokeyDbContextFactory);
            ILoginAccountProvider loginAccountProvider=new DatabaseAccountProvider(_autokeyDbContextFactory);   
            IUserCreator userCreator = new DatabaseUserCreator(_autokeyDbContextFactory);
            ISingleUserProv singleUserProvider = new DatabaseSingleUserProv(_autokeyDbContextFactory);
            ICipherCreator cipherCreator = new DatabaseCipherCreate(_autokeyDbContextFactory);
            ICipherUserProvider cipherUserProvider = new DatabaseCipherUserProvider(_autokeyDbContextFactory);
            ICipherProvider cipherProvider = new DatabaseCipherProvider(_autokeyDbContextFactory);
            ILoginAccountDelete loginAccountDelete=new DatabaseUserAccountDelete(_autokeyDbContextFactory); 
            _global = new Global(userProvider, userCreator, cipherCreator, singleUserProvider, cipherUserProvider, cipherProvider,loginAccountCreator,loginAccountProvider,loginAccountDelete);
            _navigationStore = new NavigationStore();

            m = new MainWindow()
            {


                DataContext = new MainViewModel(_navigationStore)
            };

            p = new ProfileWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            
            
        }



        protected override async void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(connection_string).Options;
            using (AutokeyDbContext dbContext = _autokeyDbContextFactory.CreateDbContext())
            {

                dbContext.Database.Migrate();
            }

            await _global.DeleteAccounts();





            _navigationStore.CurrentViewModel = CreateLoginViewModel();




           


            

            
            m.Show();
            


            base.OnStartup(e);
        }

        
        private MakeRegistrationViewModel CreateRegistrationViewModel()
        {


            return new MakeRegistrationViewModel(_global,new NavigationService(_navigationStore, CreateLoginViewModel), new NavigationService(_navigationStore, CreateLoginViewModel));
        }


        
        private LoginViewModel CreateLoginViewModel()
        {
           


            
            LoginViewModel l=   new LoginViewModel(_global, new NavigationService(_navigationStore, CreateRegistrationViewModel), new NavigationService(_navigationStore,CreateProfileViewModel), new NavigationService(_navigationStore, CreateAdminViewModel), _navigationStore,p);
         


            return l;

           
        }
        private ProfilePageViewModel CreateProfileViewModel()
        {

            
            
                 MainWindow.Hide();

            return new ProfilePageViewModel(new NavigationService(_navigationStore,CreateListPretragaViewModel), new NavigationService(_navigationStore, CreateLoginViewModel) ,new NavigationService(_navigationStore, CreateAutoKeyView), _global,_navigationStore,p,m);
           

        }

        private ListaPretragaViewModel CreateListPretragaViewModel()
        {


            return  ListaPretragaViewModel.LoadViewModel(_global, new NavigationService(_navigationStore,CreateProfileViewModel), new NavigationService(_navigationStore,CreateAutoKeyView));
        }

        private AutoKeyViewModel CreateAutoKeyView()
        {
            return new AutoKeyViewModel (new NavigationService(_navigationStore, CreateProfileViewModel), new NavigationService(_navigationStore, CreateListPretragaViewModel),_global, new NavigationService(_navigationStore, CreateLoginViewModel), _navigationStore, p, m);
        }



        private AdminViewModel CreateAdminViewModel()
        {
            MainWindow.Hide();
            return AdminViewModel.LoadAllCiphers(_global,new NavigationService(_navigationStore,CreateAdminAutoKeyView), new NavigationService(_navigationStore,CreateLoginViewModel),_navigationStore,p,m);
        }

        private AdminAutoKeyViewModel CreateAdminAutoKeyView()
        {

            return new AdminAutoKeyViewModel(new NavigationService(_navigationStore,CreateAdminViewModel),_global, new NavigationService(_navigationStore, CreateLoginViewModel),_navigationStore,p,m);
        }
    
    }
}
