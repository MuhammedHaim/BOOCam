using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AuthBOOCam.Models
{
    public class BOOCamContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BOOCamContext() : base("name=BOOCamContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            Database.SetInitializer<BOOCamContext>(null);
            base.OnModelCreating(modelBuilder);
        }
        public System.Data.Entity.DbSet<AuthBOOCam.Models.ShelfBooks> ShelfBooks { get; set; }

     
    }
}
