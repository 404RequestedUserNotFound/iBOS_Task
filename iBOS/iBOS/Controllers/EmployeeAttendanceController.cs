using iBOS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iBOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAttendanceController : ControllerBase
    {
        private readonly iBOSContext DBContext;

        public EmployeeAttendanceController(iBOSContext iBOSDBContext)
        {
            DBContext = iBOSDBContext;
        }

        [HttpPost("attendance/add")]
        public IActionResult AddEmployeeAttendance(tblEmployeeAttendance data)
        {

            DBContext.tblEmployeeAttendances.Add(data);
            DBContext.SaveChanges();

            return Ok("Employee attendance added successfully.");
        }


        [HttpGet("all")]
        public IActionResult GetAllEmployeeAttendance()
        {
            var data = DBContext.tblEmployeeAttendances.ToList();
            return Ok(data);
        }
    }
}
