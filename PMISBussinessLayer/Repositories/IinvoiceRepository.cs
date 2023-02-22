using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
    interface IinvoiceRepository
    {
        public List<Invoice> GetAllInvoices();
        public void InsertInvoice(Invoice Invoice);
        public void UpdateInvoice(Invoice Invoice);
        public void DeleteInvoice(Invoice Invoice);
        public Invoice GetInvoice(int Invoiceid);
    }
}
