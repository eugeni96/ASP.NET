using System;
using System.Web;
using System.Web.Mvc;

namespace MVC_Lesson2.Areas.Default.Controllers
{
    public class HomeController : DefaultController
    {
        public ActionResult Index()
        {
             var cookie = new HttpCookie("test_cookie")
            {
                Name = "test_cookie",
                Value = DateTime.Now.ToString("dd.MM.yyyy"),
                Expires = DateTime.Now.AddMinutes(10),
            }; 
            Response.SetCookie(cookie);

            return View();
        }
        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }
    }
}
