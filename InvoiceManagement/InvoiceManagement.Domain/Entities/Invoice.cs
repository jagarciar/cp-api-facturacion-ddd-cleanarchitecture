using InvoiceManagement.Domain.Exceptions;
using InvoiceManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Domain.Entities
{
    public class Invoice : Base
    {
        public Name CustomerName { get; private set; }
        public ValidDate DueDate { get; private set; }
        public InvoiceNumber InvoiceNumber { get; private set; }
        public ValidDate IssueDate { get; private set; }
        public InvoiceType Status { get; private set; }
        public decimal Total { get; private set; }

        public Invoice(Name customerName, ValidDate dueDate, InvoiceNumber invoiceNumber, ValidDate issueDate, InvoiceType invoiceType, decimal total)
        {
            if(customerName is null)
            {
                throw new ExceptionDomain("Customer name cannot be null.");
            }
            if(dueDate is null)
            {
                throw new ExceptionDomain("Issue date cannot be null.");
            }
            if(invoiceNumber is null)
            {
                throw new ExceptionDomain("Invoice number cannot be null.");
            }
            if(issueDate is null)
            {
                throw new ExceptionDomain("Issue date cannot be null.");
            }
            if(total < 0)
            {
                throw new ExceptionDomain("Total cannot be negative.");
            }
            if(dueDate.Value < issueDate.Value)
            {
                throw new ExceptionDomain("Due date cannot be earlier than issue date.");
            }
            this.CustomerName = customerName;
            this.InvoiceNumber = invoiceNumber;
            this.IssueDate = issueDate;
            this.DueDate = dueDate;
            this.Total = total;
            this.Status = invoiceType;
        }
        
    }
}
