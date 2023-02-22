using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PMISBussinessLayer.Entities
{
    public class Phase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Phase Name")]
        public string PhaseName { get; set; }
        public List<ProjectPhase> ProjectPhases { get; set; }
    }

}
