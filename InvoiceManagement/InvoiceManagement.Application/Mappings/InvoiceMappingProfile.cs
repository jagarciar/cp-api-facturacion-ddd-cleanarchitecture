using AutoMapper;
using InvoiceManagement.Application.DTOs;
using InvoiceManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagement.Application.Mappings
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, GetInvoiceByIdResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.InvoiceDate.IssueDate))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.InvoiceDate.DueDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<Invoice, GetAllInvoicesResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.InvoiceDate.IssueDate))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.InvoiceDate.DueDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<Invoice, CreateInvoiceRequest>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.InvoiceDate.IssueDate))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.InvoiceDate.DueDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<Invoice, CreateInvoiceResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
               .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber))
               .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.InvoiceDate.IssueDate))
               .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.InvoiceDate.DueDate))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<Invoice, UpdateInvoiceRequest>()
               .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
               .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber))
               .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.InvoiceDate.IssueDate))
               .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.InvoiceDate.DueDate))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<Invoice, UpdateInvoiceResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
               .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber))
               .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.InvoiceDate.IssueDate))
               .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.InvoiceDate.DueDate))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}
