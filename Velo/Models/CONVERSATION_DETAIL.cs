namespace Velo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONVERSATION_DETAIL
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Conversation_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string ID_User { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual CONVERSATION CONVERSATION { get; set; }
    }
}
