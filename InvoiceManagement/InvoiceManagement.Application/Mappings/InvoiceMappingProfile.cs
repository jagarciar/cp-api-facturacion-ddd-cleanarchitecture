using AutoMapper;
using InvoiceManagement.Application.DTOs;
using InvoiceManagement.Domain.Entities;
using InvoiceManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Application.Mappings
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceResponseBase>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName.Value))
                .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber.Value))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.InvoiceDate.IssueDate))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.InvoiceDate.DueDate));

            CreateMap<Invoice, GetInvoiceByIdResponse>()
                .IncludeBase<Invoice, InvoiceResponseBase>();

            CreateMap<Invoice, GetAllInvoicesResponse>()
                .IncludeBase<Invoice, InvoiceResponseBase>();

            CreateMap<Invoice, CreateInvoiceResponse>()
               .IncludeBase<Invoice, InvoiceResponseBase>();


            CreateMap<Invoice, UpdateInvoiceResponse>()
                .IncludeBase<Invoice, InvoiceResponseBase>();

            CreateMap<CreateInvoiceRequest, Invoice>()
                .ConstructUsing(src => new Invoice(
                            new CustomerName(src.CustomerName),
                            new InvoiceNumber(src.InvoiceNumber),
                            new InvoiceDate(src.IssueDate, src.DueDate),
                            src.Status,
                            src.Total
                        ));

        }
    }
}
