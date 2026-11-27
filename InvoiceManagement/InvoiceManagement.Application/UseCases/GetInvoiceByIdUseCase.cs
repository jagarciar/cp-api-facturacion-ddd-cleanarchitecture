using AutoMapper;
using InvoiceManagement.Application.DTOs;
using InvoiceManagement.Application.Interfaces;

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
