using AutoMapper;
using InvoiceManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Application.UseCases
{
    public class DeleteInvoiceUseCase
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IMapper mapper;

        public DeleteInvoiceUseCase(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;
        }

        public async Task<bool> ExecuteAsync(Guid invoiceId)
        {
            return await this.invoiceRepository.DeleteInvoice(invoiceId);
        }

    }
}
