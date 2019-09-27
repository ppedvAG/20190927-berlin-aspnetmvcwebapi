using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerlinAspNetMVC.Models.DBModel
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
