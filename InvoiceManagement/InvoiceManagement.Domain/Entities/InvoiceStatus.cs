using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Domain.Entities
{
    public enum InvoiceStatus
    {
        Draft = 1, 
        Issued = 2, 
        Paid = 3, 
        Cancelled = 4
    }
}
