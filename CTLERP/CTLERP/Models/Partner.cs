using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CTLERP.Models
{
       public class Partner
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele partenerului este obligatoriu!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Adresa partenerului este obligatorie!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Numărul de telefon este obligatoriu!")]
        public string PhoneNumber { get; set; }

        public string Fax { get; set; }

        [Required(ErrorMessage = "Email-ul este obligatoriu!")]
        [EmailAddress(ErrorMessage = "Emailul trebuie să fie o adresă de email validă!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Tipul de partener este obligatoriu!")]
        public int? PartnerTypeId { get; set; }
        public PartnerType? PartnerType { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? Type { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
