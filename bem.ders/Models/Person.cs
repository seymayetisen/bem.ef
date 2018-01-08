﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bem.ders.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Lesson> lessons { get; set; }
    }
}