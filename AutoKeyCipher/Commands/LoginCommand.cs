using AutoKeyCipher.Models;
using AutoKeyCipher.Services;
using AutoKeyCipher.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;
using AutoKeyCipher.Views;
using AutoKeyCipher.Stores;

namespace AutoKeyCipher.Commands
{
    public class LoginCommand : AsyncCommandBase
    {


        private readonly Global _global;
        private readonly NavigationService _allReservationService;
        private readonly LoginStore _loginStore;
        private readonly LoginViewModel _loginViewModel;
       private readonly NavigationStore _navigationStore;


        public LoginCommand(LoginViewModel loginViewModel, Global global, NavigationService allReservationService, NavigationStore navigationStore, LoginStore loginStore)
        {

            _loginViewModel = loginViewModel;
            _global = global;
            _allReservationService = allReservationService;
            _navigationStore = navigationStore;
            _loginViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _loginStore = loginStore;
        }


        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.Email)
             
                || e.PropertyName == nameof(LoginViewModel.Password)
               

                )
            {
                OnCanExecutedChanged();
            }
        }


        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_loginViewModel.Email) && !string.IsNullOrEmpty(_loginViewModel.Password)  && base.CanExecute(parameter);
        }



        private string HashPassword()
        {
            SHA256 hash = SHA256.Create();

            var passwordBytes = Encoding.Default.GetBytes(_loginViewModel.Password);
            var hashedPassword = hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashedPassword);
        }

        public static bool IsValidEmail(string email)
        {

            Regex emailRegex = new Regex(@"^([A-Z])?([a-z\d\.-]+)@([a-z\d-]+)\.([a-z]{2,8})(\.[a-z]{2,8})?$", RegexOptions.IgnoreCase);
        
        

            return emailRegex.IsMatch(email);   
        }

        public override async Task ExecuteAsync(object parameter)
        {



          

           
            var sifra = HashPassword();

            var count = await _global.GetAllUsers();

            
            var exists = count.Count(count => count.Email == _loginViewModel.Email && count.Password==sifra );

            
            _loginViewModel.ErrorMessage = string.Empty;


            if (exists == 1)
            {

                MessageBox.Show("Uspesno ste se ulogovali!", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);
                _allReservationService.Navigate();

                ProfileWindow p = new ProfileWindow()
                {
                    DataContext = new MainViewModel(_navigationStore)
                };


                p.Show();
               
            }
            else if (!IsValidEmail(_loginViewModel.Email))

            {
                _loginViewModel.ErrorMessage = "Neispravan format email-a!";


            }
            else
            {

                _loginViewModel.ErrorMessage = "Neispravan email ili password!";
            }
           
            
           

          
        }
    }
}
