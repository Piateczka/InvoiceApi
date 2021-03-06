﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApi.Models.DTO
{
    public class ClientDTO
    {

        public int ClientId { get; set; }
        public string Name { get; set; }

        public string Street { get; set; }
        public string PremiseNumber { get; set; }
        public string BuildingNumber { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }
        public string Country { get; set; }

        public string Nip { get; set; }
    }
}
