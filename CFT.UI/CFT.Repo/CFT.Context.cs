﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CFT.Repo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CFT_DBEntities : DbContext
    {
        public CFT_DBEntities()
            : base("name=CFT_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CAS_FeedbackData> CAS_FeedbackData { get; set; }
        public virtual DbSet<CAS_ProductInfo> CAS_ProductInfo { get; set; }

        public System.Data.Entity.DbSet<CFT.Repo.Model.CAS_ProductInfoVM> CAS_ProductInfoVM { get; set; }
    }
}