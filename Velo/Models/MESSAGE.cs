namespace Velo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MESSAGE")]
    public partial class MESSAGE
    {
        [Key]
        [StringLength(10)]
        public string Message_ID { get; set; }

        [StringLength(1000)]
        public string Message_text { get; set; }

        public DateTime? Time_sent { get; set; }

        [StringLength(10)]
        public string User_ID_sent { get; set; }

        [StringLength(10)]
        public string Conversation_ID { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual CONVERSATION CONVERSATION { get; set; }
    }
}
