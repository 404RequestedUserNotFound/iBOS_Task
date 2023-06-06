using Microsoft.EntityFrameworkCore;

namespace iBOS.Models
{
    public class iBOSContext : DbContext
    {
        public iBOSContext(DbContextOptions<iBOSContext> options) : base(options)
        {

        }

        public DbSet<tblEmployee> tblEmployees { get; set; }
        public DbSet<tblEmployeeAttendance> tblEmployeeAttendances { get; set; }
    }
}
