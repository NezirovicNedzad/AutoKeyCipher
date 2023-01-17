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
using System.Windows;

namespace AutoKeyCipher.Commands
{
    public class MakeRegistrationCommand :AsyncCommandBase
    {


        private readonly Global _global;
        private readonly NavigationService _allReservationService;
        private readonly MakeRegistrationViewModel _makeRegistrationViewModel;





        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_makeRegistrationViewModel.Name) || !string.IsNullOrEmpty(_makeRegistrationViewModel.Email) || !string.IsNullOrEmpty(_makeRegistrationViewModel.Username) || !string.IsNullOrEmpty(_makeRegistrationViewModel.Password) &&  base.CanExecute(parameter);
        }
        public MakeRegistrationCommand(MakeRegistrationViewModel makeRegistrationViewModel, Global global,
            NavigationService allReservationService )
        {
            _makeRegistrationViewModel = makeRegistrationViewModel;
            _global = global;
             _allReservationService = allReservationService;
            _makeRegistrationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeRegistrationViewModel.Name)
                || e.PropertyName == nameof(MakeRegistrationViewModel.Email)
                || e.PropertyName == nameof(MakeRegistrationViewModel.Username)
                || e.PropertyName == nameof(MakeRegistrationViewModel.Password)
                
                )
            {
                OnCanExecutedChanged(); 
            }
        }

        public override async Task ExecuteAsync(object? parameter)
        {

            
            string sifra = HashPassword();
            User user = new User(_makeRegistrationViewModel.Name, _makeRegistrationViewModel.Username, _makeRegistrationViewModel.Email, sifra);

            try
            {

               await _global.AddUser(user);
                
                MessageBox.Show("Uspesno registracija!Ulogujte se radi pristupa sajtu.", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);


                _allReservationService.Navigate();
            }
            catch (Exception)
            {

                MessageBox.Show("GreskaBaze", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
              
            

         

        }

        private string HashPassword()
        {
            SHA256 hash = SHA256.Create();

            var passwordBytes = Encoding.Default.GetBytes(_makeRegistrationViewModel.Password);
           var hashedPassword= hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashedPassword); 
        }
    }
}
