using InvoiceManagement.Application.Interfaces;
using InvoiceManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Application
{
    public static class InyeccionDependencias
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IInvoiceManagementService, InvoiceManagementService>();
            return services;
        }
    }
}
