using Bem.Ef.Models;
using Bem.Ef.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bem.Ef.Web.Controllers
{
    public class TwoTierController : BaseController
    {

        //"Data Source=DESKTOP-S3O5AOR;Initial Catalog=Zimmet;Integrated Security=True";;

        // GET: TwoTier
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PeopleAndItemList()
        {
            List<Person> list = GetAllPersonList();
            List<Item> itemList = GetAllItemsList();

            return View("~/views/twotier/_PeopleList.cshtml", list);
        }

        public ActionResult PeopleListWithoutLayout()
        {
            List<Person> list = GetAllPersonList();

            return View("~/views/twotier/_PeopleList.cshtml", list);
        }



        public ActionResult PeopleHaveItemListWithoutLayout()
        {
            var list = new List<Person>();

            using (var sqlConn = CreateAndOpenConnection())
            {
                var sqlCommand = new SqlCommand(@"SELECT * FROM Person AS p 
INNER JOIN PersonItem AS pe ON p.Id = pe.PersonId
WHERE pe.GivenDate is null", sqlConn);
                var rdr = sqlCommand.ExecuteReader();

                while (rdr.Read())
                {
                    list.Add(ConvertRdrToPerson(rdr));
                }
            }

            return View("~/views/twotier/_PeopleList.cshtml", list);

        }

        public ActionResult PeopleHaveNotItemListWithoutLayout()
        {
            var list = new List<Person>();

            using (var sqlConn = CreateAndOpenConnection())
            {
                var sqlCommand = new SqlCommand(@"SELECT * FROM Person AS p 
INNER JOIN PersonItem AS pe ON p.Id = pe.PersonId
WHERE pe.GivenDate is NOT null", sqlConn);
                var rdr = sqlCommand.ExecuteReader();

                while (rdr.Read())
                {
                    list.Add(ConvertRdrToPerson(rdr));
                }
            }

            return View("~/views/twotier/_PeopleList.cshtml", list);

        }

        public ActionResult PersonDetail(int id)
        {
            var person = new Person();
            var items = new List<Item>();

            using (var sqlConn = CreateAndOpenConnection())
            {
                var sqlCommand = new SqlCommand($"SELECT * FROM Person WHERE Id = {id}", sqlConn);
                using (var rdr = sqlCommand.ExecuteReader())
                {
                    rdr.Read();
                    person = ConvertRdrToPerson(rdr);
                }

                items = GetPersonItems(sqlConn, id);

            }

            var vm = new PersonDeteailVM
            {
                Person = person,
                Items = items
            };

            return View(vm);

        }

        public ActionResult PeopleFilterByName()
        {

            var list = new List<Person>();

            using (var sqlConn = CreateAndOpenConnection())
            {
                var sqlCommand = new SqlCommand(@"SELECT * FROM Person Where", sqlConn);
                var rdr = sqlCommand.ExecuteReader();

                while (rdr.Read())
                {
                    list.Add(ConvertRdrToPerson(rdr));
                }
            }

            return View("~/views/twotier/_PeopleList.cshtml", list);
        }


        public ActionResult PersonItems(int id)
        {
            var person = new Person();
            var items = new List<Item>();

            using (var sqlConn = CreateAndOpenConnection())
            {

                items = GetPersonItems(sqlConn, id);

            }


            return View(items);
        }


        public List<Item> GetPersonItems(SqlConnection conn, int id)
        {
            var items = new List<Item>();

            var sqlCommandForItems = new SqlCommand($"SELECT * FROM Item AS a INNER JOIN PersonItem AS p ON a.Id = p.ItemId WHERE p.PErsonId = {id}", conn);


            using (var rdrItems = sqlCommandForItems.ExecuteReader())
            {
                while (rdrItems.Read())
                {
                    items.Add(new Item
                    {
                        ItemId = Convert.ToInt32(rdrItems["Id"]),
                        Name = rdrItems["name"].ToString()
                    });
                }
            }

            return items;
        }
    }
}