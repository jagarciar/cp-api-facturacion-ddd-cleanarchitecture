using InvoiceManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Application.DTOs
{
    public class UpdateInvoiceResponse
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceNumber { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly DueDate { get; set; }
        public InvoiceStatus Status { get; set; }
        public decimal Total { get; set; }
    }
}
