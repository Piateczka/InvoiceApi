using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InvoiceApi.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceRow = new HashSet<InvoiceRow>();
        }

        [Key]
        public int InvoiceId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int? Number { get; set; }
        [Column(TypeName = "date")]
        public DateTime SellDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime IssueDate { get; set; }
        public int PaymentTime { get; set; }
        public bool IsPayed { get; set; }
        public decimal NettoValue { get; set; }
        public decimal GrossValue { get; set; }
        public int ClientId { get; set; }
        public int PaymentTypeId { get; set; }

        [ForeignKey(nameof(PaymentTypeId))]
        [InverseProperty("Invoice")]
        public virtual PaymentType PaymentType { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("Invoice")]
        public virtual Client Client { get; set; }
        [InverseProperty("Invoice")]
        public virtual ICollection<InvoiceRow> InvoiceRow { get; set; }
    }
}