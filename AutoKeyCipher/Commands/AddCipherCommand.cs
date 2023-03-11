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
    public class AddCipherCommand : AsyncCommandBase
    {

        private readonly Global _global;
        private readonly ProfilePageViewModel _profilePageViewModel;
      

        public AddCipherCommand(Global global, ProfilePageViewModel profilePageViewModel)
        {
            _global = global;
            _profilePageViewModel = profilePageViewModel;
             
        }

        public async override Task ExecuteAsync(object parameter)
        {


            Account a = await _global.GetAccount();
          Guid guid= Guid.NewGuid();
            Cipher c = new Cipher(guid,a.Email,  _profilePageViewModel.AutoKey, _profilePageViewModel.PlaintextUpper,_profilePageViewModel.Coded);


            try
            {
                await _global.AddCipher(c);
                MessageBox.Show("Uspešno je sačivano vaše šifriranje.Probajte ponovo!.", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);
          
            }
            catch (Exception)
            {

                throw ;
            }
           
         
        }
    }
}
