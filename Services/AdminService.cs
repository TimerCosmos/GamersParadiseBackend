using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models.DataBase;

namespace Services
{
    public class AdminService(IUnitOfWork unitOfWork)
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public string AddPostReactionType(PostReactionTypes postReactionType)
        {
            string action = _unitOfWork.AdminRepository.AddPostReactionType(postReactionType);
            if (action == "Success")
            {
                _unitOfWork.Commit();
            }
            return action;
        }
        public IEnumerable<PostReactionTypes> ReturnPostReactionTypes()
        {
            return _unitOfWork.AdminRepository.ReturnPostReactionTypes();
        }
        public IEnumerable<Roles> ReturnRoles()
        {
            return _unitOfWork.AdminRepository.ReturnRoles();
        }
        public string AddRole(Roles role)
        {
            string action = _unitOfWork.AdminRepository.AddRole(role);
            if(action == "Success")
                _unitOfWork.Commit();
            return action;
        }
    }
}
