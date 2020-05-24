using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApi.Models
{
    public partial class InvoiceRow
    {
        [Key]
        public int InvoiceRowId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        [Required]
        [StringLength(10)]
        public string Unit { get; set; }
        public int VarRate { get; set; }
        public int InvoiceId { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty("InvoiceRow")]
        public virtual Invoice Invoice { get; set; }
    }
}
