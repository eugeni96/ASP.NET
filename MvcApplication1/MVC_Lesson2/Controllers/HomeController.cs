using LessonProject.Model;
using Ninject;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Lesson2.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public IRepository Repository { get; set; }

        public ActionResult Index()
        {
            var roles = Repository.Roles.ToList();
            return View(roles);
        }
    }
}
