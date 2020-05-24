using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InvoiceApi.Models
{
    public partial class Client
    {
        public Client()
        {
            Invoice = new HashSet<Invoice>();
        }

        [Key]
        public int ClientId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Street { get; set; }
        [Required]
        [StringLength(6)]
        public string PremiseNumber { get; set; }

        [StringLength(6)]
        public string BuildingNumber { get; set; }
        [Required]
        [StringLength(6)]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(20)]
        public string Country { get; set; }
        [StringLength(10)]
        public string Nip { get; set; }

        [InverseProperty("Client")]
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
