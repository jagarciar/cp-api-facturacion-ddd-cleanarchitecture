using InvoiceManagement.Domain.Exceptions;


namespace InvoiceManagement.Domain.ValueObjects
{
    public record InvoiceDate
    {
        public DateOnly DueDate { get; }
        public DateOnly IssueDate { get;  }

        public InvoiceDate(DateOnly issueDate, DateOnly dueDate)
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
