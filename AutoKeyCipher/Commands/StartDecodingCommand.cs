using AutoKeyCipher.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Commands
{
    public class StartDecodingCommand : CommandBase
    {
        private static String alphabet
    = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private readonly ProfilePageViewModel _viewModel;

        public StartDecodingCommand(ProfilePageViewModel viewModel)
        {
            _viewModel = viewModel;
        }



        public override void Execute(object? parameter)
        {

            string plainText = _viewModel.Plaintext.Replace(" ", "");
            string autoKey = _viewModel.Key.Replace(" ","");



            // generating the keystream
            string newKey = autoKey + plainText;




            newKey = newKey.Substring(0, newKey.Length
          - autoKey.Length);

_viewModel.AutoKey = newKey.ToUpper();
            _viewModel.PlaintextUpper = plainText.ToUpper();



            int len = plainText.Length;
       
         
            string encryptMsg = "";

            // applying encryption algorithm
          
           


            for (int x = 0; x < len; x++)
            {
                int first = alphabet.IndexOf(plainText.ToUpper()[x]);
                int second = alphabet.IndexOf(newKey.ToUpper()[x]);
                int total = (first + second) % 26;
                encryptMsg += alphabet[total];
            }
            _viewModel.Coded = encryptMsg;
           
            

        }
    }
}
