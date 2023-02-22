using System.ComponentModel.DataAnnotations;

namespace PMISBussinessLayer.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string  Name { get; set; }
        public string  Email { get; set; }
    }

}
