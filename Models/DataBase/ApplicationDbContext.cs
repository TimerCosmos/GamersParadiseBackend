using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Models.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Gamers> Gamers { get; set; }
        public DbSet<Studios> Studios { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<GamesCategories> GamesCategories { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<AttachmentTypes> AttachmentTypes { get; set; }
        public DbSet<Attachments> Attachments { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Replies> Replies { get; set; }
        public DbSet<PostReactionTypes> PostReactionTypes { get; set; }
        public DbSet<PostVotes> PostVotes { get; set; }
        public DbSet<PostReactions> PostReactions { get; set; }
        public DbSet<Followers> Followers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasKey(role => role.RoleId);

            modelBuilder.Entity<Users>().HasKey(user => user.UserId);
            modelBuilder.Entity<Users>().HasOne(user => user.Role).WithOne(role => role.User).HasForeignKey<Users>(user => user.RoleId);

            modelBuilder.Entity<Gamers>().HasKey(gamer => gamer.GamerId);
            modelBuilder.Entity<Gamers>().HasOne(gamer => gamer.User).WithOne(user => user.Gamer).HasForeignKey<Gamers>(gamer => gamer.UserId);

            modelBuilder.Entity<Studios>().HasKey(studio => studio.StudioId);
            modelBuilder.Entity<Studios>().HasOne(studio => studio.User).WithOne(user => user.Studio).HasForeignKey<Studios>(studio => studio.UserId);

            modelBuilder.Entity<Categories>().HasKey(category => category.CategoryId);

            modelBuilder.Entity<Games>().HasKey(game => game.GameId);
            modelBuilder.Entity<Games>().HasOne(game => game.Studio).WithMany(studio => studio.Games).HasForeignKey(game => game.StudioId);

            modelBuilder.Entity<GamesCategories>().HasKey(gameCategory => new { gameCategory.CategoryId, gameCategory.GameId });
            modelBuilder.Entity<GamesCategories>().HasOne(gameCategory => gameCategory.Category).WithMany(category => category.GamesCategories).HasForeignKey(gc => gc.CategoryId);
            modelBuilder.Entity<GamesCategories>().HasOne(gameCategory => gameCategory.Game).WithMany(game => game.GamesCategories).HasForeignKey(gc => gc.GameId);

            modelBuilder.Entity<Posts>().HasKey(post => post.PostId);
            modelBuilder.Entity<Posts>().HasOne(post => post.User).WithMany(user => user.Posts).HasForeignKey(post => post.UserId);
            modelBuilder.Entity<Posts>().HasOne(post => post.Game).WithMany(game => game.Posts).HasForeignKey(post => post.GameId);

            modelBuilder.Entity<AttachmentTypes>().HasKey(attachmentType => attachmentType.AttachmentTypeId);

            modelBuilder.Entity<Attachments>().HasKey(attachment => attachment.AttachmentId);
            modelBuilder.Entity<Attachments>().HasOne(attachment => attachment.AttachmentType).WithMany(attachmentType => attachmentType.Attachments).HasForeignKey(attachment => attachment.AttachmentTypeId);
            modelBuilder.Entity<Attachments>().HasOne(attachment => attachment.Post).WithMany(post => post.Attachments).HasForeignKey(attachment => attachment.PostId);

            modelBuilder.Entity<Comments>().HasKey(comment => comment.CommentId);
            modelBuilder.Entity<Comments>().HasOne(comment => comment.User).WithMany(user => user.Comments).HasForeignKey(comment => comment.UserId); ;
            modelBuilder.Entity<Comments>().HasOne(comment => comment.Post).WithMany(post => post.Comments).HasForeignKey(comment => comment.PostId);

            modelBuilder.Entity<Replies>().HasKey(reply => new { reply.ReplyId, reply.CommentId });
            modelBuilder.Entity<Replies>().HasOne(reply => reply.Reply).WithMany(comment => comment.Replies).HasForeignKey(reply => reply.ReplyId);
            modelBuilder.Entity<Replies>().HasOne(reply => reply.RepliedTo).WithMany(comment => comment.OriginalComments).HasForeignKey(reply => reply.CommentId);
        
            modelBuilder.Entity<PostReactionTypes>().HasKey(postReactionType => postReactionType.ReactionTypeId);
            
            modelBuilder.Entity<PostVotes>().HasKey(vote => vote.VoteId);
            modelBuilder.Entity<PostVotes>().HasOne(vote => vote.Post).WithMany(post => post.Votes).HasForeignKey(vote => vote.PostId);
            modelBuilder.Entity<PostVotes>().HasOne(vote => vote.Gamer).WithMany(gamer => gamer.Votes).HasForeignKey(vote => vote.GamerId);

            modelBuilder.Entity<PostReactions>().HasKey(reaction => reaction.ReactionId);
            modelBuilder.Entity<PostReactions>().HasOne(reaction => reaction.User).WithMany(user => user.PostReactions).HasForeignKey(reaction => reaction.UserId);
            modelBuilder.Entity<PostReactions>().HasOne(reaction => reaction.Post).WithMany(post => post.PostReactions).HasForeignKey(reaction => reaction.PostId);

            modelBuilder.Entity<Followers>().HasKey(follower => new { follower.FollowedId, follower.FollowerId });
            modelBuilder.Entity<Followers>().HasOne(follower => follower.Follower).WithMany(user => user.Followers).HasForeignKey(follower => follower.FollowerId);
            modelBuilder.Entity<Followers>().HasOne(follower => follower.Following).WithMany(user => user.Following).HasForeignKey(following => following.FollowedId);
        }
    }
}
