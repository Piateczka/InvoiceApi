using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApi.Models.DTO
{
    public class InvoiceRowDTO
    {
        public int InvoiceRowId { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public int VarRate { get; set; }
        public int InvoiceId { get; set; }
    }
}
