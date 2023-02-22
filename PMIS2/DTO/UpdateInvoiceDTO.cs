using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PMIS2.DTO
{
    public class UpdateInvoiceDTO
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
