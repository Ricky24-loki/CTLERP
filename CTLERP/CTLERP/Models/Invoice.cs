using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTLERP.Models
{
    public class Invoice()
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Factura trebuie asociata unei comenzi!")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public decimal AmountDue { get; set; }
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(30);
    }
}
