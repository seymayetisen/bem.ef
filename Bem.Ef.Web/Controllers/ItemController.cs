using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bem.Ef.Web.Controllers
{
    public class ItemController : BaseController
    {
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }
    }
}