using AutoMapper;
using InvoiceManagement.Application.DTOs;
using InvoiceManagement.Application.Interfaces;
using InvoiceManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Application.UseCases
{
    public class UpdateInvoiceUseCase
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IMapper mapper;

        public UpdateInvoiceUseCase(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;
        }

        public async Task<UpdateInvoiceResponse?> ExecuteAsync(Guid invoiceId, UpdateInvoiceRequest updateInvoiceRequest)
        {
            var invoice = await this.invoiceRepository.GetInvoiceById(invoiceId);
            if (invoice == null)
            {
                return null;
            }
            invoice.Update(new CustomerName(updateInvoiceRequest.CustomerName), new InvoiceNumber(updateInvoiceRequest.InvoiceNumber), new InvoiceDate(updateInvoiceRequest.IssueDate, updateInvoiceRequest.DueDate), updateInvoiceRequest.Status, updateInvoiceRequest.Total);
            var invoiceResult = await this.invoiceRepository.UpdateInvoice(invoice);
            if (invoiceResult == null)
            {
                return null;
            }
            return this.mapper.Map<UpdateInvoiceResponse>(invoiceResult);
        }
    }
}
