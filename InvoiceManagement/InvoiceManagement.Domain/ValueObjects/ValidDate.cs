using InvoiceManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Domain.ValueObjects
{
    public record ValidDate
    {
        public DateOnly Value { get; private set; }

        public ValidDate(DateOnly value)
        {
            if(value < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ExceptionDomain($"The {nameof(Value)} cannot be in the past.");
            }
            this.Value = value;
        }
    }
}
