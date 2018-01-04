using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bem.Ef.Web.Controllers
{
    public class TierLessController : Controller
    {
        // GET: TierLess
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PeopleListWithoutLayout()
        {
            return View();
        }

        public ActionResult PeopleHaveItemListWithoutLayout()
        {
            return View();
        }

        public ActionResult PeopleHaveNotItemListWithoutLayout()
        {
            return View();
        }

        public ActionResult PeopleFilterByName()
        {
            return View();
        }
    }
}