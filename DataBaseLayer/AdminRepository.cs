using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.DataBase;

namespace DataBaseLayer
{
    public class AdminRepository(ApplicationDbContext dbContext) : IAdminRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public string AddPostReactionType(PostReactionTypes postReactionType)
        {
            try
            {
                var reactionTypes = _dbContext.Set<PostReactionTypes>().Where(reaction => reaction.ReactionEmoji == postReactionType.ReactionEmoji).FirstOrDefault();
                if (reactionTypes != null)
                    return "EmojiExists";
                reactionTypes = _dbContext.Set<PostReactionTypes>().Where(reaction => reaction.ReactionName == postReactionType.ReactionName).FirstOrDefault();
                if (reactionTypes != null)
                    return "EmojiNameExists";
                _dbContext.Set<PostReactionTypes>().Add(postReactionType);
                return "Success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<PostReactionTypes> ReturnPostReactionTypes()
        {
            try
            {
                var ReactionTypes = _dbContext.Set<PostReactionTypes>();
                return [.. ReactionTypes];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AddRole(Roles role)
        {
            var Role = _dbContext.Set<Roles>().Where(r => r.Role == role.Role).FirstOrDefault();
            if (Role != null)
                return "RoleExists";
            _dbContext.Set<Roles>().Add(role);
            return "Success";
        }
        public IEnumerable<Roles> ReturnRoles()
        {
            return [.. _dbContext.Set<Roles>()];
        }
    }
}
