using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Services.Exceptions
{
    public class DBConcurrencyException : ApplicationException
    {
        public DBConcurrencyException(String message) : base(message) { }
    }
}
