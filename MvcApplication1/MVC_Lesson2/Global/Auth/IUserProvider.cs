using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LessonProject.Model;

namespace MVC_Lesson2.Global.Auth
{
    public interface IUserProvider
    {
        User User { get; set; }
    }
}