using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApi.Models.DTO
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public ClientDTO client { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int? Number { get; set; }
        public DateTime SellDate { get; set; }
        public DateTime IssueDate { get; set; }
        public int PaymentTime { get; set; }
        public decimal NettoValue { get; set; }
        public decimal GrossValue { get; set; }
        public PaymentTypeDTO PaymentType { get; set; }
        public List<InvoiceRowDTO> InvoiceRow { get; set; }
    }
}
