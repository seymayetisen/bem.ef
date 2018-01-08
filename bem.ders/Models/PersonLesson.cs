using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bem.ders.Models
{
    public class PersonLesson
    {
        public int Id { get; set; }
        public Person person { get; set; }
        public Lesson Lesson { get; set; }
    }
}