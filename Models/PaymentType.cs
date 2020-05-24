using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApi.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
