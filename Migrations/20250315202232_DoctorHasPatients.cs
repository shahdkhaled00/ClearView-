using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClearView.Migrations
{
    /// <inheritdoc />
    public partial class DoctorHasPatients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DoctorId",
                table: "Users",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_DoctorId",
                table: "Users",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_DoctorId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DoctorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Users");
        }
    }
}
