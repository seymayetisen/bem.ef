using Bem.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bem.Ef.Data.Ef.Repository
{
    public class PersonRepository: BaseRepository
    {
        public List<Person> GetAllPerson()
        {
            using (var context = CreateContext())
            {
                return context.Person.ToList();
            }
        }

        public List<Person> GetAllPersonHaveItem()
        {
            using (var context = CreateContext())
            {
                return context.Person
                    //.Where(i=>i.Items.Any())
                    .ToList();
            }
        }

        public List<Person> GetAllPersonHaveNotItem()
        {
            using (var context = CreateContext())
            {
                return context.Person
                    //.Where(i => !i.Items.Any())
                    .ToList();
            }
        }


        public List<Person> GetPersonFilterByName(string name)
        {
            using (var context = CreateContext())
            {
                return context.Person.Where(i => i.FirstName.Contains(name)).ToList();
            }
        }
    }
}
