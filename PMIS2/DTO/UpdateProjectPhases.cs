using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMIS2.DTO
{
    public class UpdateProjectPhases
    {
        public  int ProjectPhaseId { get; set; }
        public int PhaseId { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
