﻿using System.Drawing.Imaging;
using System.IO;
using LessonProject.Model;
using MVC_Lesson2.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;
using MVC_Lesson2.Global;
using MVC_Lesson2.Mail;
using MVC_Lesson2.Models.Info;
using MVC_Lesson2.Models.ViewModels;
using MVC_Lesson2.Tools;

namespace MVC_Lesson2.Areas.Default.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult Index(int page = 1, string searchString = null)
        {
            ViewBag.Search = searchString;
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                var list = SearchEngine.Search(searchString, Repository.Users).AsQueryable();
                var data = new PageableData<User>(list, page, 5);
                return View(data);
            }
            else
            {
                var data = new PageableData<User>(Repository.Users, page, 5);
                return View(data);
            }
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
            if (userView.BirthdateDay == 0 || userView.BirthdateMonth == 0 || userView.BirthdateYear == 0)
            {
                ModelState.AddModelError("BirthDay", "Дата рождения не указана");
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

        [Authorize]
        public ActionResult Edit(int id)
        {
            var user = Repository.Users.FirstOrDefault(p => p.ID == id);
            if (user != null)
            {
                if (CurrentUser.InRoles("admin") || CurrentUser.ID == id)
                {
                    //Разрешено редактирование
                    return View(user);
                }
                return RedirectToLoginPage;
            }
            return RedirectToNotFoundPage;
        }

        public ActionResult SubscriptionTest()
        {
            var mailController = new MailController();

            var email = mailController.Subscription("Привет, мир!", CurrentUser.Email);
            email.Deliver();
            return Content("OK");
        }
    }
}
