using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMISBussinessLayer.Entities
{
    public class ProjectPhase
    {
        [Key]
        public int Id { get; set; } 

        // fk - uniqe
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        // fk - uniqe
        [ForeignKey("PhaseId")]
        public int PhaseId { get; set; }
        public Phase Phase { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Phase Start Date")]
        public DateTime StartDate { get; set; } 
        [DataType(DataType.Date)]
        [Display(Name = "Phase End Date")]
        public DateTime EndDate { get; set; }
    }

}
