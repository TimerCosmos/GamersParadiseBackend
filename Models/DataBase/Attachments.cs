using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataBase
{
    [Table("gamersparadise_attachments")]
    public class Attachments
    {
        [Column("attachmentid")]
        public Guid AttachmentId { get; set; }

        [Column("attachmentlink")]
        public string? AttachmentLink { get; set; }

        [Column("postid")]
        public Guid PostId { get; set; }

        [Column("attachmenttypeid")]
        public int AttachmentTypeId { get; set; }

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
        public Posts? Post {  get; set; }
        public AttachmentTypes? AttachmentType { get; set; }
    }
}
