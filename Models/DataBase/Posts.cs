using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataBase
{
    [Table("gamersparadise_posts")]
    public class Posts
    {
        [Column("postid")]
        public Guid PostId { get; set; }

        [Column("posttext")]
        public string? PostText { get; set; }

        [Column("userid")]
        public Guid UserId { get; set; }

        [Column("gameid")]
        public Guid GameId { get; set; }

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
        public Users? User { get; set; }
        public Games? Game { get; set; }
        public ICollection<Attachments>? Attachments { get; set; }
        public ICollection<Comments>? Comments { get; set; }
        public ICollection<PostVotes>? Votes { get; set; }
        public ICollection<PostReactions>? PostReactions { get; set; }
    }
}
