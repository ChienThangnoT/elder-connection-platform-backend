using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infracstructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "service_type_hours",
                table: "ServiceType");

            migrationBuilder.AddColumn<string>(
                name: "service_type_hours",
                table: "Service",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "service_type_hours",
                table: "Service");

            migrationBuilder.AddColumn<string>(
                name: "service_type_hours",
                table: "ServiceType",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
