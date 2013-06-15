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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.Infrastructure;
    
    internal partial class TreeMember_Mapping : EntityTypeConfiguration<TreeMember>
    {
        public TreeMember_Mapping()
        {                        
              this.HasKey(t => t.Id);        
              this.ToTable("TreeMembers");
              this.Property(t => t.Id).HasColumnName("Id");
              this.Property(t => t.TreeId).HasColumnName("TreeId");
              this.Property(t => t.MemberId).HasColumnName("MemberId");
              this.HasRequired(t => t.Tree).WithMany(t => t.Members).HasForeignKey(d => d.TreeId);
              this.HasRequired(t => t.Member).WithMany(t => t.Trees).HasForeignKey(d => d.MemberId);
         }
    }
}

