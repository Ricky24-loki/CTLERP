using System.ComponentModel.DataAnnotations;

namespace CTLERP.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        public decimal AmountDue { get; set; } = 0;
        public ICollection<OrderItem>? OrderItems { get; set; }
        [Required]
        public bool IsValid { get; set; }
        
        public int? PartnerId { get; set; }
        public Partner? Partner { get; set; }
    }
}
