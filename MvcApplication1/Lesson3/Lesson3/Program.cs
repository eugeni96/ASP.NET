using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonProject;
using LessonProject.Model; 
using System.Configuration;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new LessonProjectDbDataContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            var roles = context.Roles.ToList();
            foreach (var role in roles)
            {
                Console.WriteLine("{0} {1} {2}", role.ID, role.Code, role.Name);
            }
            Console.ReadLine();
        }
    }
}
