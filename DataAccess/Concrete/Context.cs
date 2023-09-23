﻿using Entity;
using Entity.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccess.Concrete
{
    public class Context : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }


        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Entry> Contents { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Writer> Writers { get; set; }


    }
}
