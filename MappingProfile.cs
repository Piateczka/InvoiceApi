using AutoMapper;
using InvoiceApi.Models;
using InvoiceApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InvoiceRowDTO, InvoiceRow>();
            CreateMap<InvoiceRow, InvoiceRowDTO>();

            CreateMap<InvoiceDTO, Invoice>();
            CreateMap<Invoice, InvoiceDTO>();

            //CreateMap<InvoiceDTO, Client>();
            CreateMap<ClientDTO, Client>();
            CreateMap<Client, ClientDTO>();

            CreateMap<PaymentType, PaymentTypeDTO>();
            CreateMap<PaymentTypeDTO, PaymentType>();





        }
    }
}
