using InvoiceManagement.Domain.Exceptions;


namespace InvoiceManagement.Domain.ValueObjects
{
    public record InvoiceNumber
    {
        public string Value { get; }

        public InvoiceNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ExceptionDomain("Invoice number cannot be empty.");
            }
            this.Value = value.Trim();
        }
    }
}
