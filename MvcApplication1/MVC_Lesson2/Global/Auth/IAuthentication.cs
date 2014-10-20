using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using LessonProject.Model;

namespace MVC_Lesson2.Global.Auth
{
    public interface IAuthentication
    {
        HttpContext HttpContext { get; set; }

        User Login(string userName, string Password, bool isPersistent);

        User Login(string login);

        void LogOut();

        IPrincipal CurrentUser { get; }
    }
}