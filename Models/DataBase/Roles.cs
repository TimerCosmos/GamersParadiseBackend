using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataBase
{
    [Table("gamersparadise_roles")]
    public class Roles
    {
        [Column("roleid")]
        public int RoleId { get; set; }
        [Column("role")]
        public string? Role { get; set; }
        [Column("createdon")]
        public DateTime CreatedOn { get; set; } = DateTime.Now.ToUniversalTime();
        [Column("createdby")]
        public string? CreatedBy { get; set; }
        [Column("modifiedon")]
        public DateTime ModifiedOn { get; set; } = DateTime.Now.ToUniversalTime();
        [Column("modifiedby")]
        public string? ModifiedBy { get;set; }
        [Column("isactive")]
        public bool IsActive { get; set; } = true;
        public Users? User { get; set; }

    }
}
