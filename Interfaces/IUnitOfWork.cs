using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IGamersRepository UserRepository { get; }
        public IAdminRepository AdminRepository { get; }
        void Commit();
    }
}
