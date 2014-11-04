using System.Linq;
using System.Web.Mvc;
using MVC_Lesson2.Controllers;

namespace MVC_Lesson2.Areas.Default.Controllers
{
    public class RoleController : BaseController
    {
        public ActionResult Index()
        {
            var roles = Repository.Roles.ToList();
            return View(roles);
        }
    }
}
