using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataBase
{
    [Table("gamersparadise_comments")]
    public class Comments
    {
        [Column("commentid")]
        public Guid CommentId { get; set; }

        [Column("comment")]
        public string? Comment { get; set; }

        [Column("userid")]
        public Guid UserId { get; set; }

        [Column("postid")]
        public Guid PostId { get; set; }

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
        public Posts? Post {  get; set; }
        public ICollection<Replies>? Replies { get; set; }
        public ICollection<Replies>? OriginalComments { get; set; }
    }
}
