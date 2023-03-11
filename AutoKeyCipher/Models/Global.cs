using AutoKeyCipher.Services.CipherCreator;
using AutoKeyCipher.Services.CipherProvider;
using AutoKeyCipher.Services.CipherUserProvider;
using AutoKeyCipher.Services.LoginAccountCreator;
using AutoKeyCipher.Services.LoginAccountDelete;
using AutoKeyCipher.Services.LoginAccountProvider;
using AutoKeyCipher.Services.SingleUserProvider;
using AutoKeyCipher.Services.UserCreator;
using AutoKeyCipher.Services.UsersProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyCipher.Models
{
    public class Global:DomainObjectId
    {

       
        private readonly IUserProvider _usersProvider;
        

        private readonly IUserCreator _userCreator;

        private readonly ICipherCreator _cipherCreator;

        private readonly ISingleUserProv _singleUserProv;

        private readonly ICipherUserProvider _cipherUserProvider;

        private readonly ICipherProvider _cipherProvider;
        private readonly ILoginAccountCreator _loginAccountCreator;

        private readonly ILoginAccountProvider _loginAccountProvider;

        private readonly ILoginAccountDelete _loginAccountDelete;
        public Global(IUserProvider usersProvider, IUserCreator userCreator, ICipherCreator cipherCreator, ISingleUserProv singleUserProv, ICipherUserProvider cipherUserProvider, ICipherProvider cipherProvider, ILoginAccountCreator loginAccountCreator, ILoginAccountProvider loginAccountProvider, ILoginAccountDelete loginAccountDelete)
        {
            _usersProvider = usersProvider;
            _userCreator = userCreator;
            _cipherCreator = cipherCreator;
            _singleUserProv = singleUserProv;
            _cipherUserProvider = cipherUserProvider;
            _cipherProvider = cipherProvider;
            _loginAccountCreator = loginAccountCreator;
            _loginAccountProvider = loginAccountProvider;
            _loginAccountDelete = loginAccountDelete;
        }

        public async Task <IEnumerable<User>>GetAllUsers()
        {


            return  await _usersProvider.GetAllUsers();
        }


        public async Task AddUser(User user)
        {

            await _userCreator.CreateUser(user);   
        }

        public async Task AddCipher(Cipher c)
        {

            await _cipherCreator.CreateCipher(c);
        }
        public async Task AddAccount(Account c)
        {

            await _loginAccountCreator.CreateAccount(c);
        }
        public async Task<Account> GetAccount()
        {
          return  await _loginAccountProvider.GetSingleAccount();
        }

        public async Task DeleteAccounts()
        {
            await _loginAccountDelete.DeleteUserAcc();
        }

        public async Task<User> GetUser(string email)
        {

            User user= await _singleUserProv.GetSingleUser(email);
            return user;
        }

        public async Task <IEnumerable<Cipher>>GetCiphersForUser(string email)
        {
             return await _cipherUserProvider.GetCiphers(email);
        }


        public async Task<IEnumerable<Cipher>> GetAllC()
        {
          return  await _cipherProvider.GetAllCiphers();
        }


    }
}
