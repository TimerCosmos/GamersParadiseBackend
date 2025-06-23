using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models.DataBase;
using Models.Exceptions;

namespace DataBaseLayer
{
    public class GamersRepository(ApplicationDbContext dbContext) : IGamersRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        private static string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16); 
            using var pbkdf2 = new Rfc2898DeriveBytes(password,salt,100_000,HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);
            byte[] hashBytes = new byte[48];
            Buffer.BlockCopy(salt, 0, hashBytes, 0, 16);
            Buffer.BlockCopy(hash, 0, hashBytes, 16, 32);
            return Convert.ToBase64String(hashBytes);
        }
        private static bool VerifyPassword(string password, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);
            byte[] salt = new byte[16];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, 16);
            using var pbkdf2 = new Rfc2898DeriveBytes(password,salt,100_000,HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);
            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }

            return true;
        }
        public string RegisterUser(Users user)
        {
            try
            {
                var existingUser = _dbContext.Set<Users>().FirstOrDefault(u => u.EmailAddress == user.EmailAddress);
                if (existingUser != null)
                    return "EmailExists";
                existingUser = _dbContext.Set<Users>().FirstOrDefault(u => u.UserName == user.UserName);
                if (existingUser != null)
                    return "UsernameExists";
                user.RoleId = _dbContext.Set<Roles>().Where(role => role.Role == "Gamer").Select(role => role.RoleId).FirstOrDefault();
                user.Gamer = new Gamers();
                user.HashedPassword = HashPassword(user.HashedPassword);
                _dbContext.Set<Users>().Add(user);
                return "Success";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Users GetUserByEmail(string email)
        {
            try
            {
                var user = _dbContext.Set<Users>().FirstOrDefault(u => u.EmailAddress == email);
                if (user == null)
                    throw new UserNotFoundException(email);
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Users UserLogin(string email, string password)
        {
            try
            {
                var user = _dbContext.Set<Users>().FirstOrDefault(u => u.EmailAddress == email) ?? throw new UserNotFoundException(email);
                if (!VerifyPassword(password, user.HashedPassword))
                    throw new InvalidPasswordException(email);
                user.LastLoggedOn = DateTime.Now.ToUniversalTime();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ICollection<PostReactionTypes> ReturnPostReactionTypes()
        {
            try
            {
                return [.. _dbContext.Set<PostReactionTypes>().Where(reactionType => reactionType.IsActive)];
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
