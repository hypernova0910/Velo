namespace Velo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONVERSATION")]
    public partial class CONVERSATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONVERSATION()
        {
            MESSAGEs = new HashSet<MESSAGE>();
        }

        [Key]
        [StringLength(10)]
        public string Conversation_ID { get; set; }

        [StringLength(10)]
        public string User_ID1 { get; set; }

        [StringLength(10)]
        public string User_ID2 { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual ACCOUNT ACCOUNT1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MESSAGE> MESSAGEs { get; set; }
    }
}
