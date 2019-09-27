using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.BLModels
{
    public class Owner
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public IEnumerable<Guid> Todos { get; set; }
    }
}
