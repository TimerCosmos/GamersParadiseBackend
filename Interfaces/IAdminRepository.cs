using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DataBase;

namespace Interfaces
{
    public interface IAdminRepository
    {
        public string AddPostReactionType(PostReactionTypes postReactionType);
        public IEnumerable<PostReactionTypes> ReturnPostReactionTypes();
        public string AddRole(Roles role);
        public IEnumerable<Roles> ReturnRoles();
    }
}
