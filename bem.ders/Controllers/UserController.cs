using bem.ders.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bem.ders.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            var context = new LessonContext();
            List<Person> Person = context.Person.ToList();
            
            return View(Person);
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Lessons(string UserName,string Sifre)
        {
            //SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=Lessons;Integrated Security=True");
            //SqlCommand cmd=new SqlCommand("select * ")
            return View();
        }
    }
}