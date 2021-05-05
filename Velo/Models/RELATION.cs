namespace Velo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RELATION")]
    public partial class RELATION
    {
        [Key]
        [StringLength(10)]
        public string Rela_ID { get; set; }

        [StringLength(10)]
        public string Account_ID_Sent { get; set; }

        [StringLength(10)]
        public string Account_ID_received { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual ACCOUNT ACCOUNT1 { get; set; }
    }
}
