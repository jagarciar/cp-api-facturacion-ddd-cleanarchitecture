using InvoiceManagement.Application.DTOs;
using InvoiceManagement.Application.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly CreateInvoiceUseCase createInvoiceUseCase;
        private readonly GetAllInvoicesUseCase getAllInvoicesUseCase;
        private readonly GetInvoiceByIdUseCase getInvoiceByIdUseCase;
        private readonly UpdateInvoiceUseCase updateInvoiceUseCase; 
        private readonly DeleteInvoiceUseCase deleteInvoiceUseCase;

        public InvoicesController(
            CreateInvoiceUseCase createInvoiceUseCase,
            GetAllInvoicesUseCase getAllInvoicesUseCase,
            GetInvoiceByIdUseCase getInvoiceByIdUseCase,
            UpdateInvoiceUseCase updateInvoiceUseCase,
            DeleteInvoiceUseCase deleteInvoiceUseCase)
        {
            this.createInvoiceUseCase = createInvoiceUseCase;
            this.getAllInvoicesUseCase = getAllInvoicesUseCase;
            this.getInvoiceByIdUseCase = getInvoiceByIdUseCase;
            this.updateInvoiceUseCase = updateInvoiceUseCase;
            this.deleteInvoiceUseCase = deleteInvoiceUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await this.getAllInvoicesUseCase.ExecuteAsync();
            return Ok(invoices);
        }

        [HttpGet("{invoiceId}")]
        public async Task<IActionResult> GetInvoiceById(Guid invoiceId)
        {
            var invoice = await this.getInvoiceByIdUseCase.ExecuteAsync(invoiceId);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceRequest createInvoiceRequest)
        {
            var createdInvoice = await this.createInvoiceUseCase.ExecuteAsync(createInvoiceRequest);
            return CreatedAtAction(nameof(GetInvoiceById), new { invoiceId = createdInvoice.Id }, createdInvoice);
        }

        [HttpPut("{invoiceId}")]
        public async Task<IActionResult> UpdateInvoice(Guid invoiceId, [FromBody] UpdateInvoiceRequest updateInvoiceRequest)
        {
            var updatedInvoice = await this.updateInvoiceUseCase.ExecuteAsync(invoiceId,updateInvoiceRequest);
            if (updatedInvoice == null)
            {
                return NotFound();
            }
            return Ok(updatedInvoice);
        }

        [HttpDelete("{invoiceId}")]
        public async Task<IActionResult> DeleteInvoice(Guid invoiceId)
        {
            var deleted = await this.deleteInvoiceUseCase.ExecuteAsync(invoiceId);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
