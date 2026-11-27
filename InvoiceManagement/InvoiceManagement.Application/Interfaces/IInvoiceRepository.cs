using InvoiceManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Application.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<Invoice> CreateInvoice(Invoice invoice);
        Task<List<Invoice>> GetAllInvoices();
        Task<Invoice?> GetInvoiceById(Guid invoiceId);
        Task<Invoice?> UpdateInvoice(Invoice invoice);
        Task<bool> DeleteInvoice(Guid invoiceId);
    }
}
