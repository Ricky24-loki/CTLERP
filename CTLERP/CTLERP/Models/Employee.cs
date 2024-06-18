using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTLERP.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Prenumele este obligatoriu!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Departamentul este obligatoriu!")]
        public string DepartmentId { get; set; }

        [Required(ErrorMessage = "Poziția este obligatorie!")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Data angajării este obligatorie!")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Salariul este obligatoriu!")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Emailul este obligatoriu!")]
        [EmailAddress(ErrorMessage = "Emailul trebuie să fie o adresă de email validă!")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }
        public Employee? Manager { get; set; }
    }
}
