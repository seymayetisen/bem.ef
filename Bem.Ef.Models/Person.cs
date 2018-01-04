using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bem.Ef.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsDeleted { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<VisitDate> Visits { get; set; }
        public List<Item> Items { get; set; }
    }
}