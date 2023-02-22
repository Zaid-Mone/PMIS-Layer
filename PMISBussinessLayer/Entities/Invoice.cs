using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMISBussinessLayer.Entities
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Invoice Title")]
        public string InvoiceTitle { get; set; }
        [Display(Name = "Invoice Date")]
        public DateTime InvoiceDate { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public List<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }
    }

}
