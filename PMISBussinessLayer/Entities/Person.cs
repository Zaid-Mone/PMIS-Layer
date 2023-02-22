using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PMISBussinessLayer.Entities
{
    public class Person : IdentityUser
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }

}
