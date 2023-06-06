using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace iBOS.Models
{
    public class tblEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int employeeId { get; set; }

        [Required]
        public string? employeeName { get; set; }

        [Required]
        public string? employeeCode { get; set; }

        [Required]
        public decimal employeeSalary { get; set; }
    }
}
