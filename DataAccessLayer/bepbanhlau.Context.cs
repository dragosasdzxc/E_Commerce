﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bepbanhlauEntities1 : DbContext
    {
        public bepbanhlauEntities1()
            : base("name=bepbanhlauEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<bill_detail> bill_detail { get; set; }
        public virtual DbSet<branch> branches { get; set; }
        public virtual DbSet<cart> carts { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<group> groups { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<status> status { get; set; }
        public virtual DbSet<sub_category> sub_category { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}
