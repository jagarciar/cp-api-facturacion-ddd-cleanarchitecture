using InvoiceManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Application.Interfaces
{
    public interface IInvoiceManagementService
    {
        Task<CreateInvoiceResponse> CreateInvoice(CreateInvoiceRequest createInvoiceRequest);
        Task<List<GetAllInvoicesResponse>> GetAllInvoices();
        Task<GetInvoiceByIdResponse?> GetInvoiceById(Guid invoiceId);
        Task<UpdateInvoiceResponse?> UpdateInvoice(Guid invoiceId, UpdateInvoiceRequest updateInvoiceRequest);
        Task<bool> DeleteInvoice(Guid invoiceId);
    }
}
