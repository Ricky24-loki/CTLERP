using System.ComponentModel.DataAnnotations;

namespace CTLERP.Models
{
    public class PartnerType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

