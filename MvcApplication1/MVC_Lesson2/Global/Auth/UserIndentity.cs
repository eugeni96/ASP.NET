using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using LessonProject.Model;
using Ninject;

namespace MVC_Lesson2.Global.Auth
{
    public class UserIndentity : IIdentity, IUserProvider
    {
        public User User { get; set; }

        public string AuthenticationType
        {
            get { return typeof (User).ToString(); }
        }

        public bool IsAuthenticated
        {
            get { return User != null; }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Email;
                }
                //иначе аноним
                return "anonym";
            }
        }

        public void Init(string email, IRepository repository)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = repository.GetUser(email);
            }
        }

        [Inject]
        public IAuthentication Auth { get; set; }

        public User CurrentUser
        {
            get { return ((IUserProvider) Auth.CurrentUser.Identity).User; }
        }
    }
}