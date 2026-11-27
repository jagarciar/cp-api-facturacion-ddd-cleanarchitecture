using AutoMapper;
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
        private readonly IMapper mapper;

        public InvoiceManagementService(IInvoiceManagementRepository invoiceRepository, IMapper iMapper)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = iMapper;
        }

        public async Task<CreateInvoiceResponse> CreateInvoice(CreateInvoiceRequest createInvoiceRequest)
        {
           var invoiceResult = await this.invoiceRepository.CreateInvoice(this.mapper.Map<Invoice>(createInvoiceRequest));
            return this.mapper.Map<CreateInvoiceResponse>(invoiceResult);
        }

        public async Task<bool> DeleteInvoice(Guid invoiceId)
        {
            return await this.invoiceRepository.DeleteInvoice(invoiceId);
        }

        public async Task<List<GetAllInvoicesResponse>> GetAllInvoices()
        {
            var invoices = await this.invoiceRepository.GetAllInvoices();
            return invoices?.Select(invoice => this.mapper.Map<GetAllInvoicesResponse>(invoice)).ToList() ?? new List<GetAllInvoicesResponse>();
        }

        public async Task<GetInvoiceByIdResponse?> GetInvoiceById(Guid invoiceId)
        {
            return this.mapper.Map<GetInvoiceByIdResponse>(await this.invoiceRepository.GetInvoiceById(invoiceId));
        }

        public async Task<UpdateInvoiceResponse?> UpdateInvoice(Guid invoiceId, UpdateInvoiceRequest updateInvoiceRequest)
        {
            var invoice = await this.invoiceRepository.GetInvoiceById(invoiceId);
            if (invoice == null)
            {
                return null;
            }
            invoice.Update(new CustomerName(updateInvoiceRequest.CustomerName), new InvoiceNumber(updateInvoiceRequest.InvoiceNumber), new InvoiceDate(updateInvoiceRequest.IssueDate, updateInvoiceRequest.DueDate), updateInvoiceRequest.Status, updateInvoiceRequest.Total);
            var invoiceResult = await this.invoiceRepository.UpdateInvoice(invoice);
            if(invoiceResult == null)
            {
                return null;
            }
            return this.mapper.Map<UpdateInvoiceResponse>(invoiceResult);
        }
    }
}
