using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClearView.Migrations
{
    /// <inheritdoc />
    public partial class AlterUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "BookingPrice",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MedicalLicenseNumber",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearsExperience",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClinicId",
                table: "Users",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Clinics_ClinicId",
                table: "Users",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Clinics_ClinicId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ClinicId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BookingPrice",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MedicalLicenseNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "YearsExperience",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    BookingPrice = table.Column<int>(type: "int", nullable: false),
                    MedicalLicenseNumber = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearsExperience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ClinicId",
                table: "Doctors",
                column: "ClinicId");
        }
    }
}
