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


        private readonly ProfilePageViewModel _viewModel;

        public StartDecodingCommand(ProfilePageViewModel viewModel)
        {
            _viewModel = viewModel;
        }



        public override void Execute(object? parameter)
        {



            int len = _viewModel.Plaintext.Length;
       
            // generating the keystream
            string newKey = _viewModel.Key +_viewModel.Plaintext;
            newKey = newKey.Substring(0, newKey.Length
            - _viewModel.Key.Length);

        
          string k=newKey.Replace(" ", "");
            k = k.Substring(0,k.Length);
            _viewModel.AutoKey=k.ToUpper();
            _viewModel.PlaintextUpper = _viewModel.Plaintext.ToUpper().Replace(" ", "");

           
            

        }
    }
}
