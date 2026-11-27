using InvoiceManagement.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManagement.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<Repositories.InvoiceDbContext>(options =>
            {
                options.UseInMemoryDatabase("InvoiceManagementDb");
            });
            services.AddScoped<IInvoiceRepository, Repositories.InvoiceRepository>();
            return services;
        }
    }
}
