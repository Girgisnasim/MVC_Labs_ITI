using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_Superssn",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "Superssn",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_Superssn",
                table: "Employee",
                column: "Superssn",
                principalTable: "Employee",
                principalColumn: "SSN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_Superssn",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "Superssn",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_Superssn",
                table: "Employee",
                column: "Superssn",
                principalTable: "Employee",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
