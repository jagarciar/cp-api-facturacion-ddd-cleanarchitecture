using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Domain.Exceptions
{
    public class ExceptionDomain : Exception
    {
        public ExceptionDomain(string message) : base(message) { }
    }
}
