using InvoiceManagement.Application.Interfaces;

namespace InvoiceManagement.Application.UseCases
{
    public class DeleteInvoiceUseCase
    {
        private readonly IInvoiceRepository invoiceRepository;

        public DeleteInvoiceUseCase(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public async Task<bool> ExecuteAsync(Guid invoiceId)
        {
            return await this.invoiceRepository.DeleteInvoice(invoiceId);
        }

    }
}
