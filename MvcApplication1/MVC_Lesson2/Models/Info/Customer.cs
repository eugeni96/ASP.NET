using System.Collections.Generic;

namespace MVC_Lesson2.Models.Info
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Dictionary<string, Ownership> Ownerships { get; set; }
    }
}