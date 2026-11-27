using AutoMapper;
using InvoiceManagement.Application.DTOs;
using InvoiceManagement.Application.Interfaces;
using InvoiceManagement.Domain.Entities;

namespace InvoiceManagement.Application.UseCases
{
    public class CreateInvoiceUseCase
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IMapper mapper;

        public CreateInvoiceUseCase(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;   
        }

        public async Task<CreateInvoiceResponse> ExecuteAsync(CreateInvoiceRequest createInvoiceRequest)
        {
            var invoiceResult = await this.invoiceRepository.CreateInvoice(this.mapper.Map<Invoice>(createInvoiceRequest));
            return this.mapper.Map<CreateInvoiceResponse>(invoiceResult);
        }
    }
}
