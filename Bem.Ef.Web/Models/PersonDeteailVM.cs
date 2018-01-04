using Bem.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bem.Ef.Web.Models
{
    public class PersonDeteailVM
    {
        public Person Person { get; set; }
        public List<Item> Items { get; set; }
    }
}