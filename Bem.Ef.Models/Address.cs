﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bem.Ef.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AddresLine { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
