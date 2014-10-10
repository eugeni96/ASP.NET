using System.Drawing.Imaging;
using LessonProject.Model;
using MVC_Lesson2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Lesson2.Models.ViewModels;
using MVC_Lesson2.Tools;

namespace MVC_Lesson2.Areas.Default.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult Index()
        {
            var users = Repository.Users.ToList();
            return View(users);
        }
        [HttpGet]
        public ActionResult Register()
        {
            var newUserView = new UserView();
            return View(newUserView);
        }

        [HttpPost]
        public ActionResult Register(UserView userView)
        {
            if (userView.Captcha != (string)Session[CaptchaImage.CaptchaValueKey])
            {
                ModelState.AddModelError("Captcha", "Текст с картинки введен неверно");
            }
            var anyUser = Repository.Users.Any(p => string.Compare(p.Email, userView.Email) == 0);
            if (anyUser)
            {
                ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован");
            }

            if (ModelState.IsValid)
            {
                var user = (User)ModelMapper.Map(userView, typeof(UserView), typeof(User));

                Repository.CreateUser(user);
                return RedirectToAction("Index");
            }
            return View(userView);
        }

        public ActionResult Captcha()
        {
            Session[CaptchaImage.CaptchaValueKey] = new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString();
            var ci = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 211, 50, "Arial");

            // Change the response headers to output a JPEG image.
            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";

            // Write the image to the response stream in JPEG format.
            ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

            // Dispose of the CAPTCHA image object.
            ci.Dispose();
            return null;
        }



    }
}
