using AutoMapper;
using InvoiceManagement.Application.DTOs;
using InvoiceManagement.Application.Interfaces;

namespace InvoiceManagement.Application.UseCases
{
    public class GetAllInvoicesUseCase
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IMapper mapper;

        public GetAllInvoicesUseCase(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;
        }

        public async Task<List<GetAllInvoicesResponse>> ExecuteAsync()
        {
            var invoices = await this.invoiceRepository.GetAllInvoices();
            return invoices?.Select(invoice => this.mapper.Map<GetAllInvoicesResponse>(invoice)).ToList() ?? new List<GetAllInvoicesResponse>();
        }
    }
}
