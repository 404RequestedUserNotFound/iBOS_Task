using iBOS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace iBOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly iBOSContext DBContext;

        public EmployeeController(iBOSContext iBOSDBContext)
        {
            DBContext = iBOSDBContext;
        }



        [HttpPost("add")]
        public IActionResult AddEmployee(tblEmployee data)
        {

            if (DBContext.tblEmployees.Any(e => e.employeeCode == data.employeeCode))
            {
                return BadRequest("Employee code already exists. Please provide a unique employee code.");
            }

            DBContext.tblEmployees.Add(data);
            DBContext.SaveChanges();

            return Ok("Employee information addded successfully.");
        }



        [HttpGet("all")]
        public IActionResult GetAllEmployee()
        {
            var data = DBContext.tblEmployees.ToList();
            return Ok(data);
        }


        //[For API01]
        [HttpPut("update/{id}")]
        public IActionResult UpdateEmployeeCode(int id, string employeeCode)
        {
            var data = DBContext.tblEmployees.Find(id);
            if (data == null)
            {
                return NotFound("Could not found the entered employee id.");
            }

            if (DBContext.tblEmployees.Any(e => e.employeeCode == employeeCode))
            {
                return BadRequest("Please enter a valid employee code. This employee code already exists.");
            }


            data.employeeCode = employeeCode;
            DBContext.SaveChanges();

            return Ok("Employee code updated successfully.");
        }


        //[For API02]
        [HttpGet]
        [Route("salary/maximum-to-minimum")]
        public IActionResult GetEmployeeSalary()
        {
            var data = DBContext.tblEmployees.OrderByDescending(e => e.employeeSalary).ToList();
            return Ok(data);
        }


        //[For API03]
        [HttpGet("absent")]
        public IActionResult GetAbsentEmployee()
        {
            var data = DBContext.tblEmployees
                .Where(e => DBContext.tblEmployeeAttendances.Any(a => a.employeeId == e.employeeId && a.isAbsent))
                .ToList();

            return Ok(data);
        }


        //[For API04]
        [HttpGet("attendance-report")]
        public IActionResult GetEmployeeAttendanceReport()
        {
            var data = DBContext.tblEmployees.Select(e => new
            {
                EmployeeName = e.employeeName,
                MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month),
                TotalPresent = DBContext.tblEmployeeAttendances.Count(a => a.employeeId == e.employeeId && a.isPresent),
                TotalAbsent = DBContext.tblEmployeeAttendances.Count(a => a.employeeId == e.employeeId && a.isAbsent),
                TotalOffday = DBContext.tblEmployeeAttendances.Count(a => a.employeeId == e.employeeId && a.isOffday)
            }).ToList();

            return Ok(data);
        }
    }
}
