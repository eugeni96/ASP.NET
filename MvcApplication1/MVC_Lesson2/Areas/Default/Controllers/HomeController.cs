using LessonProject.Model;
using MVC_Lesson2.Controllers;
using Ninject;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Lesson2.Areas.Default.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
