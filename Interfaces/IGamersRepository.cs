using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DataBase;

namespace Interfaces
{
    public interface IGamersRepository
    {
        public string RegisterUser(Users user);
        public Users GetUserByEmail(string email);
        public Users UserLogin(string email, string password);
        public ICollection<PostReactionTypes> ReturnPostReactionTypes();
    }
}
