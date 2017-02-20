using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult customers()
        {
            return PartialView("customers");
        }

        public ActionResult editCustomer()
        {
            return PartialView("editCustomer");
        }
    }
}