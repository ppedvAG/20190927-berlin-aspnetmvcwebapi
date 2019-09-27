using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DBModels
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<TodoOwner> TodoOwners { get; set; }
    }
}
