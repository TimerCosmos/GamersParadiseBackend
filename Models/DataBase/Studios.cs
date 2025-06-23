using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataBase
{
    [Table("gamersparadise_studios")]
    public class Studios
    {
        [Column("studioid")]
        public Guid StudioId { get; set; }
        [Column("userid")]
        public Guid UserId { get; set; }
        public Users? User { get; set; }
        public ICollection<Games>? Games { get; set; }
    }
}
