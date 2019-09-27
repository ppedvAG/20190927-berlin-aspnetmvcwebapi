using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services.Exceptions
{
    public class ObjectNotFoundException: Exception
    {
        public ObjectNotFoundException(string message): base(message)
        {

        }
    }
}
