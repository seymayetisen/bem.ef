using Bem.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bem.Ef.EfLayer.Repository
{
    public class PersonRepository
    {
        public List<Person> GetAllPerson()
        {
            using (var context = new ZimmetDbContext())
            {
                return context.Person.ToList();
            }
        }

    }
}
