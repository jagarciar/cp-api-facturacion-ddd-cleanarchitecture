using AutoMapper;
using InvoiceManagement.Application.DTOs;
using InvoiceManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Application.UseCases
{
    public class GetInvoiceByIdUseCase
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IMapper mapper;

        public GetInvoiceByIdUseCase(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;
        }

        public async Task<GetInvoiceByIdResponse?> ExecuteAsync(Guid invoiceId)
        {
            return this.mapper.Map<GetInvoiceByIdResponse>(await this.invoiceRepository.GetInvoiceById(invoiceId));
        }
    }
}
