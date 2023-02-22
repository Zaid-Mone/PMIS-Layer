using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMIS2.DTO
{
    public class UpdatePaymentTermDTO
    {
        public int Id { get; set; }
        [Display(Name = "PaymentTerm Title")]
        public string PaymentTermTitle { get; set; }
        [Display(Name = "PaymentTerm Amount")]
        public decimal PaymentTermAmount { get; set; }
       
        public int DeliverableId { get; set; }
        public Deliverable Deliverable { get; set; }
        public List<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }

    }
}
