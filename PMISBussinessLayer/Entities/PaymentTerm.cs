using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMISBussinessLayer.Entities
{
    public class PaymentTerm
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "PaymentTerm Title")]
        public string PaymentTermTitle { get; set; }
        [Display(Name = "PaymentTerm Amount")]
        public decimal PaymentTermAmount { get; set; }
        [ForeignKey("DeliverableId")]
        public int DeliverableId { get; set; }
        public Deliverable Deliverable { get; set; }
        public List<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }

    }

}
