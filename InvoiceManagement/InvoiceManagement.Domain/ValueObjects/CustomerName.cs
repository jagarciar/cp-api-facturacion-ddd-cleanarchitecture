using InvoiceManagement.Domain.Exceptions;

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
            this.Value = value.Trim();
        }
    }
}
