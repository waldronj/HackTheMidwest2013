﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#pragma warning disable 1573
namespace HackMW2013.Models
{
    using System;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CallingTreeModelContainer : DbContext
    {
        static CallingTreeModelContainer()
    	{ 
    		Database.SetInitializer<CallingTreeModelContainer>(null);
    	}
    	
    	public CallingTreeModelContainer() : base("name=CallingTreeModelContainer")
        {
        }
    	
    	public CallingTreeModelContainer(string nameOrConnectionString) : base(nameOrConnectionString)
    	{	
    	}
    
    	public CallingTreeModelContainer(string nameOrConnectionString, DbCompiledModel model) : base(nameOrConnectionString, model)
    	{
    	}
    
    	public CallingTreeModelContainer(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
    	{
    	}
    
    	public CallingTreeModelContainer(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection) : base(existingConnection, model, contextOwnsConnection)
    	{
    	}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {		
    		modelBuilder.Configurations.Add(new Chat_Mapping());
    		modelBuilder.Configurations.Add(new Member_Mapping());
    		modelBuilder.Configurations.Add(new Tree_Mapping());
    		modelBuilder.Configurations.Add(new TreeMember_Mapping());
        }
    	
        public DbSet<Member> Members { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Tree> Trees { get; set; }
        public DbSet<TreeMember> TreeMembers { get; set; }
    }
}
