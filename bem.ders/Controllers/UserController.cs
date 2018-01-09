using bem.ders.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
        public SqlConnection createConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=Lessons;Integrated Security=True");
            conn.Open();
            return conn;
        }
        public JsonResult Lessons(string UserName,string Sifre)
        {
            List<Lesson> lessons = new List<Lesson>();
            using (SqlConnection conn = createConnection())
            {

                SqlCommand cmd = new SqlCommand("select * from Lessons l inner join PersonLessons pl on l.Id = pl.Lesson_Id inner join People p on p.Id = pl.Person_Id where p.UserName=@username and p.Password=@Sifre", conn);
                cmd.Parameters.AddWithValue("@username", UserName);
                cmd.Parameters.AddWithValue("@Sifre", Sifre);

                using (SqlDataReader result = cmd.ExecuteReader())
                {
                    while (result.Read())
                    {
                        Lesson ders = new Lesson
                        {
                            Id = (int)result["Id"],
                            Name = result["Name"].ToString(),
                            HourPerWeek = (int)result["HourPerWeek"]

                        };
                        lessons.Add(ders);
                    }
                }
                conn.Close();
            }
            var context = new LessonContext();
            




            return Json(lessons, JsonRequestBehavior.AllowGet);
        }
    }
}