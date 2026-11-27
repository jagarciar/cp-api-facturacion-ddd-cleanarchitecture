using InvoiceManagement.Domain.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.OwnsOne(i => i.CustomerName, customerName =>
                {
                    customerName.Property(x => x.Value)
                    .IsRequired();
                });
                entity.OwnsOne(i => i.InvoiceNumber, invoiceNumber =>
                {
                    invoiceNumber.Property(x => x.Value)
                    .IsRequired();
                });
                entity.OwnsOne(i => i.InvoiceDate, invoiceDate =>
                {
                    invoiceDate.Property(x => x.IssueDate)
                    .IsRequired();
                invoiceDate.Property(x => x.DueDate)
                .IsRequired();
                });
            });
        }
    }
}