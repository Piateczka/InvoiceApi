using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApi.Models
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Client> Client { get; set; }
        public DbSet<Invoice> Invoice { get; set; }

        public DbSet<InvoiceRow> InvoiceRow { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public List<Invoice> getInvoices() => Invoice.ToList();

        public List<Client> getClient() => Client.ToList();
        public List<PaymentType> getPaymentType() => PaymentType.ToList();

        public int AddClient(Client client)
        {
            Client.Add(client);
            this.SaveChanges();
            return client.ClientId;
        }
        public int UpdateClient(Client client)
        {
            Client.Update(client);
            this.SaveChanges();
            return client.ClientId;
        }
        public int UpdateInvoice(Invoice invoice)
        {
            Invoice.Update(invoice);
            this.SaveChanges();
            return invoice.InvoiceId;
        }


        public int AddInvoice(Invoice invoice)
        {

            invoice.Month = DateTime.Now.Month;
            invoice.Year = DateTime.Now.Year;
            var Number = Invoice.Where(inv => inv.Month == invoice.Month && inv.Year == inv.Year).Max(a => a.Number);
            invoice.Number = Number + 1 ?? 1;
            Invoice.Add(invoice);
            this.SaveChanges();
            return invoice.InvoiceId;
        }
        public void AddInvoiceRows(List<InvoiceRow> invoiceRows, int id)
        {
            foreach (var ir in invoiceRows)
            {
                ir.InvoiceId = id;
                InvoiceRow.Add(ir);
                this.SaveChanges();
            }


        }

        public Client GetClientById(int id)
        {
            var client = Client.Where(c => c.ClientId == id).FirstOrDefault();
            return client;
        }
        //public Client GetClientByData(string nip,string name)
        //{
        //    var client = Client.Where(c => c.Nip == id).FirstOrDefault();
        //    return client;
        //}
        public List<InvoiceRow> GetInvoiceRow(int id)
        {
            var iRows = InvoiceRow.Where(i => i.InvoiceId == id).ToList();
            return iRows;
        }
        public PaymentType GetPaymentType(int id)
        {
            var pt = PaymentType.Where(i => i.PaymentTypeId == id).FirstOrDefault();
            return pt;
        }

        public int GetClientId(string name, string nip)
        {
            int id = Client.Where(a => a.Name == name || a.Nip == nip).Select(c => c.ClientId).FirstOrDefault();

            return id;
        }

        public List<Client> FindClientByName(string name)
        {
            var client = Client.Where(c => c.Name.StartsWith(name)).ToList();
            return client;
        }
        public List<Client> FindClientByNip(string nip)
        {
            var client = Client.Where(c => c.Nip.StartsWith(nip)).ToList();
            return client;
        }

        public List<Invoice> FindInvoiceByNumber(int number)
        {
            var invoice = Invoice.Where(i => i.Number.Equals(number)).ToList();
            return invoice;
        }

        public List<Client> DeleteClient(int number)
        {
            try
            {
                var invoice = Invoice.Where(a => a.ClientId == number).ToList();
                foreach (var item in invoice)
                {
                    var invoiceRow = InvoiceRow.Where(i => i.InvoiceId == item.InvoiceId).ToList();
                    foreach (var ir in invoiceRow)
                    {
                        InvoiceRow.Remove(ir);
                        this.SaveChanges();
                    }
                    Invoice.Remove(item);
                    this.SaveChanges();
                }
                var client = Client.Where(a => a.ClientId == number).FirstOrDefault();
                Client.Remove(client);
                this.SaveChanges();


                return Client.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Invoice> DeleteInvoice(int number)
        {
            try
            {
                var invoiceRow = InvoiceRow.Where(a => a.InvoiceId == number).ToList();
                foreach (var item in invoiceRow)
                {
                    InvoiceRow.Remove(item);
                    this.SaveChanges();
                }
                var invoice = Invoice.Where(a => a.InvoiceId == number).FirstOrDefault();
                Invoice.Remove(invoice);
                this.SaveChanges();


                return Invoice.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public Invoice GetInvoice(int number)
        {




            var invoice = Invoice.Where(i => i.InvoiceId.Equals(number)).FirstOrDefault();
            return invoice;
        }

        public string GetClientName(int id)
        {
            var clientName = Client.Where(c => c.ClientId == id).Select(c => c.Name).FirstOrDefault();
            return clientName;
        }
    }
}
