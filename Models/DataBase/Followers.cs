using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataBase
{
    [Table("gamersparadise_userfollowers")]
    public class Followers
    {
        [Column("followerid")]
        public Guid FollowerId { get; set; }
        [Column("followedid")]
        public Guid FollowedId { get; set; }
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
        public Users? Follower {  get; set; }
        public Users? Following { get; set; }
    }
}
