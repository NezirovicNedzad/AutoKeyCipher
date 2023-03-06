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

        private List<Cipher> ciphers= new List<Cipher>();
        private readonly IUserProvider _usersProvider;

        private readonly IUserCreator _userCreator;


     

        public Global(IUserProvider usersProvider, IUserCreator userCreator)
        {
            _usersProvider = usersProvider;
            _userCreator = userCreator;
        }

        public async Task <IEnumerable<User>>GetAllUsers()
        {


            return  await _usersProvider.GetAllUsers();
        }


        public async Task AddUser(User user)
        {

            await _userCreator.CreateUser(user);   
        }

      



    }
}
