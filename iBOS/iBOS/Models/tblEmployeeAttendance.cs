using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace iBOS.Models
{
    public class tblEmployeeAttendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int employeeId { get; set; }

        [Required]
        public DateTime attendanceDate { get; set; }

        [Required]
        public bool isPresent { get; set; }

        [Required]
        public bool isAbsent { get; set; }

        [Required]
        public bool isOffday { get; set; }
    }
}
