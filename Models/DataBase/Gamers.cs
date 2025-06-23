using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataBase
{
    [Table("gamersparadise_gamers")]
    public class Gamers
    {
        [Column("gamerid")]
        public Guid GamerId { get; set; }
        [Column("userid")]
        public Guid UserId { get; set; }
        public Users? User { get; set; }
        public ICollection<PostVotes>? Votes { get; set; }
    }
}
