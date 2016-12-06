using BIMDomain.Models.Abstract;
using BIMDomain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BIMDomain.Models.DAL
{
    public class BIMObjectContext : DbContext, IBIMObjectContext
    {
        public IDbSet<Manufactury> Manufacturies { get; set; }
        public IDbSet<Product> Products { get; set; }

        public BIMObjectContext()
            : base("BIMObjectContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //removes plural to table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*
             * This is for cascade delete to work when deleting a manufactory or product
             */
            modelBuilder.Entity<Product>().HasKey(c => c.Id)
                                                .HasRequired(c => c.Manufactury)
                                                .WithMany(g => g.Products)
                                                .WillCascadeOnDelete(true);
        }
    }
}