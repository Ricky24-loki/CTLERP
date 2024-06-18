using System.ComponentModel.DataAnnotations;

namespace CTLERP.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public Order? Order { get; set; }
        public int? OrderId { get; set; }
        public Product? Product { get; set; }
        [Required(ErrorMessage = "Produsul este obligatoriu")]
        public int? ProductId { get; set; }

        [Required(ErrorMessage = "Cantitatea este obligatorie")]
        [Range(1, int.MaxValue, ErrorMessage = "Cantitatea trebuie să fie un număr pozitiv")]
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
