//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HackMW2013.Models
{
    #pragma warning disable 1573
    using System;
    using System.Collections.Generic;
    
    public partial class Chat
    {
        public int Id { get; set; }
        public string Messege { get; set; }
        public System.TimeSpan TimeStamp { get; set; }
        public int TreeId { get; set; }
        public int MemberId { get; set; }
    
        public virtual Tree Tree { get; set; }
        public virtual Member Member { get; set; }
    }
}
