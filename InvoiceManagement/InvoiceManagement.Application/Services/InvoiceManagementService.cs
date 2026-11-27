using InvoiceManagement.Application.DTOs;
using InvoiceManagement.Application.Interfaces;
using InvoiceManagement.Domain.Entities;
using InvoiceManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Application.Services
{
    public class InvoiceManagementService : IInvoiceManagementService
    {
        private readonly IInvoiceManagementRepository invoiceRepository;

        public InvoiceManagementService(IInvoiceManagementRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public async Task<CreateInvoiceResponse> CreateInvoice(CreateInvoiceRequest createInvoiceRequest)
        {
           var invoiceResult = await this.invoiceRepository.CreateInvoice(new Invoice
           (
               new CustomerName(createInvoiceRequest.CustomerName),
               new InvoiceNumber(createInvoiceRequest.InvoiceNumber),
               new InvoiceDate(createInvoiceRequest.IssueDate,createInvoiceRequest.DueDate),
               createInvoiceRequest.Status,
               createInvoiceRequest.Total
           ));
            return new CreateInvoiceResponse
            {
                Id = invoiceResult.Id,
                CustomerName = invoiceResult.CustomerName.Value,
                InvoiceNumber = invoiceResult.InvoiceNumber.Value,
                IssueDate = invoiceResult.InvoiceDate.IssueDate,
                DueDate = invoiceResult.InvoiceDate.DueDate,
                Status = invoiceResult.Status,
                Total = invoiceResult.Total
            };
        }

        public async Task<bool> DeleteInvoice(Guid invoiceId)
        {
            return await this.invoiceRepository.DeleteInvoice(invoiceId);
        }

        public async Task<List<GetAllInvoicesResponse>> GetAllInvoices()
        {
            var invoices = await this.invoiceRepository.GetAllInvoices();
            List<GetAllInvoicesResponse> response = new List<GetAllInvoicesResponse>();
            if(invoices != null)
            {
                foreach (var invoice in invoices)
                {
                    response.Add(new GetAllInvoicesResponse
                    {
                        Id = invoice.Id,
                        CustomerName = invoice.CustomerName.Value,
                        InvoiceNumber = invoice.InvoiceNumber.Value,
                        IssueDate = invoice.InvoiceDate.IssueDate,
                        DueDate = invoice.InvoiceDate.DueDate,
                        Total = invoice.Total
                    });
                }
            }
            return response;
        }

        public async Task<GetInvoiceByIdResponse?> GetInvoiceById(Guid invoiceId)
        {
            var invoice = await this.invoiceRepository.GetInvoiceById(invoiceId);
            if (invoice == null)
            {
                return null;
            }
            return new GetInvoiceByIdResponse
            {
                Id = invoice.Id,
                CustomerName = invoice.CustomerName.Value,
                InvoiceNumber = invoice.InvoiceNumber.Value,
                IssueDate = invoice.InvoiceDate.IssueDate,
                DueDate = invoice.InvoiceDate.DueDate,
                Status = invoice.Status,
                Total = invoice.Total
            };
        }

        public async Task<UpdateInvoiceResponse?> UpdateInvoice(Guid invoiceId, UpdateInvoiceRequest updateInvoiceRequest)
        {
            var invoice = await this.invoiceRepository.UpdateInvoice(invoiceId, new Invoice(new CustomerName(updateInvoiceRequest.CustomerName), new InvoiceNumber(updateInvoiceRequest.InvoiceNumber), new InvoiceDate(updateInvoiceRequest.IssueDate, updateInvoiceRequest.DueDate), updateInvoiceRequest.Status, updateInvoiceRequest.Total));
            if (invoice == null)
            {
                return null;
            }
            return new UpdateInvoiceResponse
            {
                Id = invoice.Id,
                CustomerName = invoice.CustomerName.Value,
                InvoiceNumber = invoice.InvoiceNumber.Value,
                IssueDate = invoice.InvoiceDate.IssueDate,
                DueDate = invoice.InvoiceDate.DueDate,
                Status = invoice.Status,
                Total = invoice.Total
            };
        }
    }
}
