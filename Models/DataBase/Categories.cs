using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataBase
{
    [Table("gamersparadise_gamecategorytypes")]
    public class Categories
    {
        [Column("categoryid")]
        public Guid CategoryId { get; set; }
        [Column("category")]
        public string? Category { get; set; }
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
        public ICollection<GamesCategories>? GamesCategories { get; set; }
    }
}
