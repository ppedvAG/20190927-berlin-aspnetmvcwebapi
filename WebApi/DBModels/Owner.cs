using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DBModels
{
    public class Owner
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public IEnumerable<TodoOwner> TodoOwners { get; set; }
    }
}
