using System;
using System.Linq;
using LessonProject.Model; 
using System.Configuration;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new LessonProejctDbDataContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            var roles = context.Roles.ToList();
            foreach (var role in roles)
            {
                Console.WriteLine("{0} {1} {2}", role.ID, role.Code, role.Name);
            }
            Console.ReadLine();
        }
    }
}
