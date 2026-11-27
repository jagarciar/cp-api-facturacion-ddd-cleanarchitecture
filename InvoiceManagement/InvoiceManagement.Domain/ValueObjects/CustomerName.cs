using InvoiceManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Domain.ValueObjects
{
    public record CustomerName
    {
        public string Value { get; }

        public CustomerName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ExceptionDomain("Customer name cannot be empty.");
            }
            this.Value = value;
        }
    }
}
