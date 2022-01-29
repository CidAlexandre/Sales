using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(String message) : base(message) { }
    }

}
