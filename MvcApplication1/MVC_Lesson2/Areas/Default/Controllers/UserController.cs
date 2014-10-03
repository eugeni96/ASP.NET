using MVC_Lesson2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Lesson2.Areas.Default.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            var roles = Repository.Users.ToList();
            return View(roles);
        }
    }
}
