using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models.DataBase;

namespace DataBaseLayer
{
    public class UnitOfWork(IGamersRepository userRepository, ApplicationDbContext dbContext, IAdminRepository adminRepository) : IUnitOfWork
    {
        public IGamersRepository UserRepository { get; set; } = userRepository;
        private readonly ApplicationDbContext _context = dbContext;
        public IAdminRepository AdminRepository { get; set; } = adminRepository;

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
