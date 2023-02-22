using System.ComponentModel.DataAnnotations.Schema;

namespace PMISBussinessLayer.Entities
{
    public class InvoicePaymentTerm
    {
        [ForeignKey("InvoiceId")]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        [ForeignKey("PaymentTermId")]
        public int PaymentTermId { get; set; }
        public PaymentTerm PaymentTerm { get; set; }

    }

}
