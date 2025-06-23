using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataBase
{
    [Table("gamersparadise_users")]
    public class Users
    {
        [Column("userid")]
        public Guid UserId { get; set; }
        [Column("username")]
        public string? UserName { get; set; }
        [Column("emailaddress")]
        public string? EmailAddress { get; set; }
        [Column("hashedpassword")]
        public string? HashedPassword { get; set; }
        [Column("userprofilelink")]
        public string? UserProfileLink { get; set; }
        [Column("about")]
        public string? About { get; set; }
        [Column("roleid")]
        public int RoleId { get; set; }
        [Column("lastloggedon")]
        public DateTime LastLoggedOn { get; set; } = DateTime.Now.ToUniversalTime();
        [Column("createdon")]
        public DateTime CreatedOn { get; set; } = DateTime.Now.ToUniversalTime();
        [Column("createdby")]
        public string? CreatedBy { get; set; }
        [Column("modifiedon")]
        public DateTime ModifiedOn { get; set; } = DateTime.Now.ToUniversalTime();
        [Column("modifiedby")]
        public string? ModifiedBy { get; set; }
        [Column("isactive")]
        public bool IsActive { get; set; } = true;
        public Roles? Role {  get; set; }
        public Gamers? Gamer { get; set; }
        public Studios? Studio { get; set; }
        public ICollection<Posts>? Posts { get; set; }
        public ICollection<Comments>? Comments { get; set; }
        public ICollection<PostReactions>? PostReactions { get; set; }
        public ICollection<Followers>? Followers { get; set; }
        public ICollection<Followers>? Following { get; set; }
    }
}
