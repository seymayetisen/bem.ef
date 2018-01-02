using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bem.Ef.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> Person { get; set; }
    }
}