﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bem.Ef.Models
{
    public class VisitDate
    {
        public int Id { get; set; }
        public DateTime Visit { get; set; }
        public Person Person { get; set; }
    }
}
