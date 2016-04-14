//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CIS598PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MessageBoard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MessageBoard()
        {
            this.Replies = new HashSet<Reply>();
        }
    
        public int Id { get; set; }
        public string SubmittedBy { get; set; }
        public string Description { get; set; }
        public System.DateTime Date { get; set; }
        public byte[] Image { get; set; }
        public string Type { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
