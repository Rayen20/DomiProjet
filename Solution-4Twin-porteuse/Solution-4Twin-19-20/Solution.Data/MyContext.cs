using Solution.Data.Configurations;
using Solution.Data.CustomConventions;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data
{
    public class MyContext : DbContext
    {
        public MyContext():base("name=MaChaine")
        {

        }
        public DbSet<Fichier> Fichiers { get; set; }
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FichierConfiguration());
            modelBuilder.Conventions.Add(new DateTimeConvention());
        }

    }
}
