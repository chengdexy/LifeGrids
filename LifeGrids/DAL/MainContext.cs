using LifeGrids.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace LifeGrids.DAL
{
    public class MainContext : DbContext
    {
        public MainContext() : base("MainContext")
        {

        }
        public DbSet<Life> Lifes { get; set; }
        public DbSet<Grid> Grids { get; set; }
        public DbSet<Thing> Things { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}