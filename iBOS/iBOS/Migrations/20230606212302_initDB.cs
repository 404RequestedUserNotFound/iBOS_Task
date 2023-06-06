using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iBOS.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEmployeeAttendances",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    attendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isPresent = table.Column<bool>(type: "bit", nullable: false),
                    isAbsent = table.Column<bool>(type: "bit", nullable: false),
                    isOffday = table.Column<bool>(type: "bit", nullable: false)
                });
                //constraints: table =>
                //{
                //    table.PrimaryKey("PK_tblEmployeeAttendances", x => x.employeeId);
                //});

            migrationBuilder.CreateTable(
                name: "tblEmployees",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    employeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployees", x => x.employeeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEmployeeAttendances");

            migrationBuilder.DropTable(
                name: "tblEmployees");
        }
    }
}
