﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HackMW2013.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CallingTreeModelContainer : DbContext
    {
        public CallingTreeModelContainer()
            : base("name=CallingTreeModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<TreeMember> TreeMembers { get; set; }
        public DbSet<TreeOwner> TreeOwners { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<CallingTreeList> CallingTreeLists { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
