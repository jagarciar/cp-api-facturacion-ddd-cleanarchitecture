using InvoiceManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Application.Interfaces
{
    public interface IInvoiceManagementRepository
    {
        Task<Invoice> CreateInvoice(Invoice invoice);
        Task<List<Invoice>> GetAllInvoices();
        Task<Invoice?> GetInvoiceById(Guid invoiceId);
        Task<Invoice?> UpdateInvoice(Guid invoiceId, Invoice invoice);
        Task<bool> DeleteInvoice(Guid invoiceId);
    }
}
