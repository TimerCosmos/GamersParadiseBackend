using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataBase
{
    [Table("gamersparadise_postReactions")]
    public class PostReactions
    {
        [Column("reactionid")]
        public Guid ReactionId { get; set; }

        [Column("reactiontypeid")]
        public int ReactionTypeId { get; set; }

        [Column("postid")]
        public Guid PostId { get; set; }

        [Column("userid")]
        public Guid UserId { get; set; }

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

        public Posts? Post { get; set; }
        public Users? User {  get; set; }
    }
}
