using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataBase
{
    [Table("gamersparadise_postVotes")]
    public class PostVotes
    {

        [Column("voteid")]
        public Guid VoteId { get; set; }

        [Column("vote")]
        public int Vote { get; set; }

        [Column("postid")]
        public Guid PostId { get; set; }

        [Column("gamerid")]
        public Guid GamerId { get; set; }

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
        public Gamers? Gamer {  get; set; }
    }
}
