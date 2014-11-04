using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Lesson2.Areas.Default.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Default/Customer/

        public ActionResult Index()
        {
            return View();
        }

    }
}
