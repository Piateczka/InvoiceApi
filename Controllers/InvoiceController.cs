using System;
using System.Collections.Generic;
using AutoMapper;
using InvoiceApi.Models;
using InvoiceApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApi.Controllers
{
    [ApiController]
    public class InvoiceController : ControllerBase
    {

        DatabaseContext _context;
        private readonly IMapper _mapper;
        public InvoiceController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [Route("[controller]/[action]")]
        [HttpGet]
        public IEnumerable<Invoice> GetInvoice() => _context.getInvoices();

        [HttpGet]
        [Route("[controller]/[action]&query={number}")]
        public List<Invoice> FindInvoiceByNumber(int number) => _context.FindInvoiceByNumber(number);

        [HttpDelete]
        [Route("[controller]/[action]/{id}")]
        public List<Invoice> DeleteInvoice(int id) => _context.DeleteInvoice(id);

        [HttpPost]
        [Route("[controller]/[action]")]
        public IActionResult AddInvoice([FromBody]InvoiceDTO inv)
        {

            var id = _context.GetClientId(inv.client.Name, inv.client.Nip);
            if (id != 0)
            {
                var invoice = _mapper.Map<Invoice>(inv);
                invoice.ClientId = id;
                invoice.PaymentTypeId = inv.PaymentType.PaymentTypeId;
                invoice.Client = null;
                invoice.PaymentType = null;
                var invoiceId = _context.AddInvoice(invoice);
                return Ok();
            }
            else
            {
                var invoice = _mapper.Map<Invoice>(inv);
                invoice.PaymentType = null;
                invoice.PaymentTypeId = inv.PaymentType.PaymentTypeId;
                var invoiceId = _context.AddInvoice(invoice);
                return Ok();
            }


        }


        [HttpGet]
        [Route("[controller]/[action]/{id}")]
        public InvoiceDTO GetDetails(int id)
        {
            var i = _context.GetInvoice(id);
            var client = _context.GetClientById(i.ClientId);
            var iRows = _context.GetInvoiceRow(i.InvoiceId);
            var payT = _context.GetPaymentType(i.PaymentTypeId);
            var invoice = _mapper.Map<InvoiceDTO>(i);
            invoice.PaymentType = _mapper.Map<PaymentTypeDTO>(payT);
            invoice.client = _mapper.Map<ClientDTO>(client);
            var invoiceRows = _mapper.Map<List<InvoiceRowDTO>>(iRows);
            invoice.InvoiceRow = invoiceRows;
            return invoice;



        }
        [HttpPut]
        [Route("[controller]/[action]/{id}")]
        public IActionResult UpdateInvoice(int id, [FromBody]InvoiceDTO inv)
        {
            inv.InvoiceId = id;
            var i = _mapper.Map<Invoice>(inv);
            _context.UpdateInvoice(i);

            return Ok();



        }
        [Route("[controller]/[action]")]
        [HttpGet]
        public List<PaymentTypeDTO> GetPaymentType() => _mapper.Map<List<PaymentTypeDTO>>(_context.getPaymentType());



    }
}