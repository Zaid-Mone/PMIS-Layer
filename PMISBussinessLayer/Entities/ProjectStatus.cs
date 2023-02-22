using System.ComponentModel.DataAnnotations;

namespace PMISBussinessLayer.Entities
{
    public class ProjectStatus
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Project Status")]
        public string Status { get; set; }
    }

}
