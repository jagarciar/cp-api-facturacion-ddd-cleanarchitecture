using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Infraestructure.Repositories
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options)
        {
        }
        public DbSet<InvoiceManagement.Domain.Entities.Invoice> Invoices => Set<InvoiceManagement.Domain.Entities.Invoice>();
    }
}