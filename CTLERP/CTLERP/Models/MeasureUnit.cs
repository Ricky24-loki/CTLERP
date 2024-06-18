using System.ComponentModel.DataAnnotations;

namespace CTLERP.Models
{
    public class MeasureUnit
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Numele este obligatoriu")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Prescurtarea este obligatorie")]
        public string Abbreviation { get; set; }
    }
}

