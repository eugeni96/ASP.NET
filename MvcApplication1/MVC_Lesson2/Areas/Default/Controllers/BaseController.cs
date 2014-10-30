﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LessonProject.Model;
using MVC_Lesson2.Global.Auth;
using MVC_Lesson2.Mappers;
using Ninject;

namespace MVC_Lesson2.Controllers
{
    public abstract class BaseController : Controller
    {
        [Inject]
        public IRepository Repository { get; set; }

        [Inject]
        public IMapper ModelMapper { get; set; }

        [Inject]
        public IAuthentication Auth { get; set; }
        public User CurrentUser
        {
            get
            {
                return ((UserIndentity)Auth.CurrentUser.Identity).User;
            }
        }
    }
}