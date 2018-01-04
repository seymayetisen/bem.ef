using Bem.Ef.Data;
using System.Web.Mvc;

namespace Bem.Ef.Web.Controllers
{
    public class ThreeTierController : Controller
    {
        // GET: ThreeTier
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PeopleListWithoutLayout()
        {
            var personData = new PersonData();
            var list = personData.GetAllPerson();

            return View("~/views/twotier/_PeopleList.cshtml", list);
        }

        public ActionResult PeopleHaveItemListWithoutLayout()
        {
            var personData = new PersonData();
            var list = personData.GetAllPersonHaveItem();

            return View("~/views/twotier/_PeopleList.cshtml", list);
        }

        public ActionResult PeopleHaveNotItemListWithoutLayout()
        {
            var personData = new PersonData();
            var list = personData.GetAllPersonHaveNotItem();

            return View("~/views/twotier/_PeopleList.cshtml", list);
        }

        //public ActionResult PersonDetail(int id)
        //{
        //    var person = new Person();
        //    var items = new List<Item>();

        //    using (var sqlConn = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=Zimmet;Integrated Security=True"))
        //    {
        //        var sqlCommand = new SqlCommand($"SELECT * FROM Person WHERE Id = {id}", sqlConn);
        //        sqlConn.Open();
        //        using (var rdr = sqlCommand.ExecuteReader())
        //        {
        //            rdr.Read();
        //            person = ConvertRdrToPerson(rdr);
        //        }

        //        items = GetPersonItems(sqlConn, id);

        //    }

        //    var vm = new PersonDeteailVM
        //    {
        //        Person = person,
        //        Items = items
        //    };

        //    return View(vm);

        //}

        //public ActionResult PersonItems(int id)
        //{
        //    var person = new Person();
        //    var items = new List<Item>();

        //    using (var sqlConn = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=Zimmet;Integrated Security=True"))
        //    {

        //        items = GetPersonItems(sqlConn, id);

        //    }


        //    return View(items);
        //}

    }
}
