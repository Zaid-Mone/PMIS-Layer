using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMISBussinessLayer.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [ForeignKey("ProjectTypeId")]
        public int ProjectTypeId { get; set; }
        public ProjectType ProjectType { get; set; }
        [ForeignKey("ProjectStatusId")]
        public int ProjectStatusId { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public List<ProjectPhase> ProjectPhases { get; set; }
        [Display(Name = "Contract Amount")]
        public decimal ContractAmount { get; set; }
        public string ContractFileName { get; set; }
        public string ContractFileType { get; set; }
        public Byte[] ContractFile { get; set; }
        [ForeignKey("ProjectMangerId")]
        public string ProjectMangerId { get; set; }
        public ProjectManger ProjectManger { get; set; }
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }

}
