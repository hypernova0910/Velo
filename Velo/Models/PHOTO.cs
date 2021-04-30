namespace Velo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("PHOTO")]
    public partial class PHOTO
    {
        [Key]
        [StringLength(10)]
        public string Photo_ID { get; set; }

        [StringLength(100)]
        public string Link { get; set; }

        public DateTime? Time_added { get; set; }

        [StringLength(10)]
        public string ID_User { get; set; }

        public bool? isAvatar { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
