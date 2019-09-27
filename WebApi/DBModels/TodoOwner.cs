using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DBModels
{
    public class TodoOwner
    {
        public Guid TodoId { get; set; }
        public Todo Todo { get; set; }
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
