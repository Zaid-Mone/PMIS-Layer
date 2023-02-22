using Microsoft.EntityFrameworkCore;
using PMISBussinessLayer.Data;
using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
    public class InvoiceRepository : IinvoiceRepository
    {
        private readonly ApplicationDbContext context;
        public InvoiceRepository(ApplicationDbContext context)
        {
            this.context = context;

        }
        public void DeleteInvoice(Invoice Invoice)
        {

            context.Invoices.Remove(Invoice);
            context.SaveChanges();
        }

        public List<Invoice> GetAllInvoices()
        {
            return context.Invoices.Include(p => p.Project).Include(v => v.InvoicePaymentTerms).ToList();
        }

        public Invoice GetInvoice(int Invoiceid)
        {
            return context.Invoices.SingleOrDefault(x => x.Id == Invoiceid);
        }

        public void InsertInvoice(Invoice Invoice)
        {

            context.Invoices.Add(Invoice);
            context.SaveChanges();
        }

        public void UpdateInvoice(Invoice Invoice)
        {
            context.Invoices.Update(Invoice);
            context.SaveChanges();
        }
    }
}
