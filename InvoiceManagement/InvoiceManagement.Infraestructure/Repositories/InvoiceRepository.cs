using InvoiceManagement.Application.Interfaces;
using InvoiceManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Infraestructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoiceDbContext dbContext;

        public InvoiceRepository(InvoiceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Invoice> CreateInvoice(Invoice invoice)
        {
            await this.dbContext.Invoices.AddAsync(invoice);
            await this.dbContext.SaveChangesAsync();
            return invoice;
        }

        public async Task<bool> DeleteInvoice(Guid invoiceId)
        {
            var invoice = await this.dbContext.Invoices.FindAsync(invoiceId);
            if (invoice == null)
            {
                return false;
            }
            this.dbContext.Invoices.Remove(invoice);
            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Invoice>> GetAllInvoices()
        {
            return await this.dbContext.Invoices.AsNoTracking().ToListAsync();
        }

        public async Task<Invoice?> GetInvoiceById(Guid invoiceId)
        {
            return await this.dbContext.Invoices.AsNoTracking().FirstOrDefaultAsync(i => i.Id == invoiceId);
        }

        public async Task<Invoice?> UpdateInvoice(Invoice invoice)
        {
            var existingInvoice = await this.GetInvoiceById(invoice.Id);
            if (existingInvoice == null)
            {
                return null;
            }
            this.dbContext.Invoices.Update(invoice);
            await this.dbContext.SaveChangesAsync();
            return invoice;
        }
    }
}
