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
    
    public partial class Reply
    {
        public int ID { get; set; }
        public int MBID { get; set; }
        public string Description { get; set; }
        public System.DateTime Date { get; set; }
        public string SubmittedBy { get; set; }
        public byte[] Image { get; set; }
    
        public virtual MessageBoard MessageBoard { get; set; }
        public virtual User User { get; set; }
    }
}
