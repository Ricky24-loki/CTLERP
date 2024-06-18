using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTLERP.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Numele produsului este obligatoriu!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pretul este obligatoriu!")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Cantitatea este obligatorie!")]
        public decimal Quantity { get; set; }
        [Required(ErrorMessage = "Unitatea de masura este obligatorie!")]
        public int? MeasureUnitId { get; set; }
        public MeasureUnit? MeasureUnit { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? Unit { get; set; }
    }
}
