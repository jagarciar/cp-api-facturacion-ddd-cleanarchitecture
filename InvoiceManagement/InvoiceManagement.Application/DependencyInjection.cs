using InvoiceManagement.Application.Interfaces;
using InvoiceManagement.Application.Mappings;
using InvoiceManagement.Application.Services;
using InvoiceManagement.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<CreateInvoiceUseCase>();
            services.AddScoped<UpdateInvoiceUseCase>();
            services.AddScoped<DeleteInvoiceUseCase>();
            services.AddScoped<GetAllInvoicesUseCase>();
            services.AddScoped<GetInvoiceByIdUseCase>();
            services.AddAutoMapper(cfg => { }, typeof(InvoiceMappingProfile));
            return services;
        }
    }
}
