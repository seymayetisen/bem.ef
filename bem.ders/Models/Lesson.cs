using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bem.ders.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HourPerWeek { get; set; }    
        public List<Person> Persons { get; set; }
    }
}