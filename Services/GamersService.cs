using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models.DataBase;

namespace Services
{
    public class GamersService(IUnitOfWork unitOfWork)
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public string RegisterUser(Users user)
        {
            string action = _unitOfWork.UserRepository.RegisterUser(user);
            if (action == "Success")
            {
                _unitOfWork.Commit();
            }
            return action;
        }
        public Users GetUserByEmail(string email)
        {
            return _unitOfWork.UserRepository.GetUserByEmail(email);
        }
        public Users UserLogin(string email, string password)
        {
            var user = _unitOfWork.UserRepository.UserLogin(email, password);
            _unitOfWork.Commit();
            return user;
        }
        public ICollection<PostReactionTypes> ReturnPostReactionTypes()
        {
            return _unitOfWork.UserRepository.ReturnPostReactionTypes();
        }
    }
}
