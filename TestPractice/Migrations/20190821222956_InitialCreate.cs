using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestPractice.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeDatas",
                columns: table => new
                {
                    EMPID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BIRTHDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    LASTNAME = table.Column<string>(type: "varchar(16)", nullable: true),
                    FIRSTNAME = table.Column<string>(type: "varchar(12)", nullable: true),
                    PHONE = table.Column<string>(type: "varchar(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDatas", x => x.EMPID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EMPID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HIREDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    SALARY = table.Column<string>(type: "varchar(10)", nullable: true),
                    DEPT = table.Column<string>(type: "varchar(6)", nullable: true),
                    JOBCODE = table.Column<string>(type: "varchar(10)", nullable: true),
                    SEX = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EMPID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDatas");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
