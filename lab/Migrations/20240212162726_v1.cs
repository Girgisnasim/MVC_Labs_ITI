using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Dnum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MGRSSN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Dnum);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bdate = table.Column<DateOnly>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    Superssn = table.Column<int>(type: "int", nullable: false),
                    Dno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Employee_Department_Dno",
                        column: x => x.Dno,
                        principalTable: "Department",
                        principalColumn: "Dnum");
                    table.ForeignKey(
                        name: "FK_Employee_Employee_Superssn",
                        column: x => x.Superssn,
                        principalTable: "Employee",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Pnumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dnum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Pnumber);
                    table.ForeignKey(
                        name: "FK_Project_Department_Dnum",
                        column: x => x.Dnum,
                        principalTable: "Department",
                        principalColumn: "Dnum");
                });

            migrationBuilder.CreateTable(
                name: "Dependent",
                columns: table => new
                {
                    ESSN = table.Column<int>(type: "int", nullable: false),
                    Dendent_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bdate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependent", x => new { x.ESSN, x.Dendent_name });
                    table.ForeignKey(
                        name: "FK_Dependent_Employee_ESSN",
                        column: x => x.ESSN,
                        principalTable: "Employee",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works_For",
                columns: table => new
                {
                    ESSn = table.Column<int>(type: "int", nullable: false),
                    Pno = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works_For", x => new { x.ESSn, x.Pno });
                    table.ForeignKey(
                        name: "FK_Works_For_Employee_ESSn",
                        column: x => x.ESSn,
                        principalTable: "Employee",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Works_For_Project_Pno",
                        column: x => x.Pno,
                        principalTable: "Project",
                        principalColumn: "Pnumber",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_MGRSSN",
                table: "Department",
                column: "MGRSSN",
                unique: true,
                filter: "[MGRSSN] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Dno",
                table: "Employee",
                column: "Dno");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Superssn",
                table: "Employee",
                column: "Superssn");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Dnum",
                table: "Project",
                column: "Dnum");

            migrationBuilder.CreateIndex(
                name: "IX_Works_For_Pno",
                table: "Works_For",
                column: "Pno");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employee_MGRSSN",
                table: "Department",
                column: "MGRSSN",
                principalTable: "Employee",
                principalColumn: "SSN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee_MGRSSN",
                table: "Department");

            migrationBuilder.DropTable(
                name: "Dependent");

            migrationBuilder.DropTable(
                name: "Works_For");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
