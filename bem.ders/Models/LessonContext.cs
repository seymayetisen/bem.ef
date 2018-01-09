using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using bem.ders.Models;

namespace bem.ders.Models
{
    public class LessonContext: DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        


        public LessonContext():base("Data Source=DESKTOP-S3O5AOR;Initial Catalog=Lessons;Integrated Security=True")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ZimmetContext, Configuration>());

            Database.SetInitializer<LessonContext>(new DbInitializer());
        }
        public class DbInitializer : DropCreateDatabaseAlways<LessonContext>
        {
            protected override void Seed(LessonContext context)
            {

                Person Person1 = new Person
                {
                    UserName="seyma",
                    Password="12345",
                    Name="seyma",
                    Surname="yetisen"
                };
                Lesson Lesson1 = new Lesson
                {
                    Name = "C#",
                    HourPerWeek = 5,
                    Persons = new List<Models.Person> {
                        Person1
                    } 
                };
                Lesson Lesson2 = new Lesson
                {
                    Name = "C++",
                    HourPerWeek = 3,
                    Persons = new List<Models.Person> {
                        Person1
                    }
                };


                context.Person.Add(Person1);
                context.Lesson.Add(Lesson1);
                context.Lesson.Add(Lesson2);
                

                context.SaveChanges();
                base.Seed(context);

            }
        }

    }
}