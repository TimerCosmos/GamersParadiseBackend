using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataBase
{
    [Table("GamesParadise_games")]
    public class Games
    {
        [Column("gameid")]
        public Guid GameId { get; set; }

        [Column("game")]
        public string? Game { get; set; }

        [Column("gamelogolink")]
        public string? GameLogoLink { get; set; }

        [Column("studioid")]
        public Guid StudioId { get; set; }

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
        public Studios? Studio { get; set; }
        public ICollection<GamesCategories>? GamesCategories { get; set; }
        public ICollection<Posts>? Posts { get; set; }
    }
}
