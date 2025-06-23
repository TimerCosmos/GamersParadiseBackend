using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataBase
{
    [Table("gamersparadise_replies")]
    public class Replies
    {
        [Column("replyid")]
        public Guid ReplyId { get; set; }
        [Column("commentid")]
        public Guid CommentId { get; set; }
        public Comments? Reply {  get; set; }
        public Comments? RepliedTo { get; set; }
    }
}
