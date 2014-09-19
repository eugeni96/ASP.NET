using MVC_Lesson2.App_Start;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Lesson2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [Inject]
        public IWeapon weapon { get; set; }
        public ActionResult Index()
        {
            return View(weapon);
        }

    }
}
