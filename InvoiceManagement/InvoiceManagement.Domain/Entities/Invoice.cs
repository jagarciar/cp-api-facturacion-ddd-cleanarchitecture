using InvoiceManagement.Domain.Exceptions;
using InvoiceManagement.Domain.ValueObjects;

namespace InvoiceManagement.Domain.Entities
{
    public class Invoice : Base
    {
        public CustomerName CustomerName { get; private set; }
        public InvoiceNumber InvoiceNumber { get; private set; }
        public InvoiceDate InvoiceDate { get; private set; }
        public InvoiceStatus Status { get; private set; }
        public decimal Total { get; private set; }

        public Invoice(CustomerName customerName, InvoiceNumber invoiceNumber, InvoiceDate invoiceDate, InvoiceStatus invoiceStatus, decimal total)
        {
            if(customerName is null)
            {
                throw new ExceptionDomain("Customer name cannot be null.");
            }
            if(invoiceNumber is null)
            {
                throw new ExceptionDomain("Invoice number cannot be null.");
            }
            if(invoiceDate is null)
            {
                throw new ExceptionDomain("Invoice date cannot be null.");
            }
            if(total <= 0)
            {
                throw new ExceptionDomain("Total must be greater than zero.");
            }
            if (!Enum.IsDefined(invoiceStatus))
            {
                throw new ExceptionDomain("Invalid invoice status.");
            }
            this.CustomerName = customerName;
            this.InvoiceNumber = invoiceNumber;
            this.InvoiceDate = invoiceDate;
            this.Total = total;
            this.Status = invoiceStatus;
        }
        
    }
}
