using InvoiceManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Domain.ValueObjects
{
    public record InvoiceDate
    {
        public DateOnly DueDate { get; }
        public DateOnly IssueDate { get;  }

        public InvoiceDate(DateOnly dueDate, DateOnly issueDate)
        {
            if(dueDate < issueDate)
            {
                throw new ExceptionDomain("Due date cannot be earlier than issue date.");
            }
            this.DueDate = dueDate;
            this.IssueDate = issueDate;
        }
    }
}
