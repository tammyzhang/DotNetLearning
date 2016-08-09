using System.ComponentModel.DataAnnotations;
using BusinessLayer;

namespace BusinessEntities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [FirstNameValidation]
        public string FirstName { get; set; }

        [StringLength(15,ErrorMessage = "Last Name Length should not be greater than 15.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "No blank")]
        public int? Salary { get; set; }
    }
}