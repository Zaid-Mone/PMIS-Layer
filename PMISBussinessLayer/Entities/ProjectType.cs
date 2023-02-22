using System.ComponentModel.DataAnnotations;

namespace PMISBussinessLayer.Entities
{
    public class ProjectType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Project Type")]
        public string Type { get; set; } 
    }

}
