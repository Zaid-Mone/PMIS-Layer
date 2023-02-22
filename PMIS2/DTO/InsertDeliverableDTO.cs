using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMISBussinessLayer.Entities;

namespace PMIS2.DTO
{
    public class InsertDeliverableDTO
    {
      
      public int Id { get; set; }

        [Display(Name = "Deliverable Description")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Deliverable Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }  // must be > phase start date

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Deliverable End Date")]
        public DateTime EndDate { get; set; }// must be < phase end date

        [ForeignKey("ProjectPhaseId")]
        public int ProjectPhaseId { get; set; }
        public ProjectPhase ProjectPhase { get; set; }

        public int PhaseId { get; set; }
        public Phase Phase { get; set; }
    }
}
