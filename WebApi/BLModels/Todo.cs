using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.BLModels
{
    public class Todo
    {
        [Required(AllowEmptyStrings = false)]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public IEnumerable<Guid> Owners { get; set; }
    }
}
