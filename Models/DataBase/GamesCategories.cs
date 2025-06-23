using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataBase
{
    [Table("gamersparadise_gamescategories")]
    public class GamesCategories
    {
        [Column("gameid")]
        public Guid GameId { get; set; }
        [Column("categoryid")]
        public Guid CategoryId { get; set; }
        public Games? Game { get; set; }
        public Categories? Category { get; set; }
    }
}
