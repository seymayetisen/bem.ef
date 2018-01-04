using Bem.Ef.Data.Ef.Migrations;
using Bem.Ef.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bem.Ef.Data.Ef.Context
{
    public class ZimmetContext: DbContext
    {
        public DbSet<Person> Person { get; set; }
        //public DbSet<Item> Item { get; set; }

        public ZimmetContext():base("Data Source = DESKTOP-S3O5AOR; Initial Catalog = Zimmet3; user id = orhan; password=321654;Integrated Security = True")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ZimmetContext, Configuration>());

            Database.SetInitializer(new DropCreateDatabaseAlways<ZimmetContext>());
        }
    }
}
