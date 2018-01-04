using Bem.Ef.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bem.Ef.EfLayer
{
    public class ZimmetDbContext: DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Address> Address { get; set; }

        public ZimmetDbContext():base("Data Source = DESKTOP-S3O5AOR; Initial Catalog = Zimmet3; user id = orhan; password=321654;Integrated Security = True")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ZimmetDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            ConfigurePerson(modelBuilder);

            modelBuilder.Entity<Person>().HasOptional(p => p.Address).WithRequired(p => p.Person);

            base.OnModelCreating(modelBuilder);
        }

        private static void ConfigurePerson(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Kisi");

            modelBuilder.Entity<Person>()
                .Property(p => p.FirstName)
                    .HasMaxLength(45)
                    .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(p => p.LastName)
                    .HasMaxLength(45);
        }
    }
}
