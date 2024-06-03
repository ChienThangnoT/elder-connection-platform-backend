using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infracstructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConnectorInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "location_work",
                table: "ConnectorInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "syll_behind_img",
                table: "ConnectorInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "syll_front_img",
                table: "ConnectorInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "location_work",
                table: "ConnectorInfo");

            migrationBuilder.DropColumn(
                name: "syll_behind_img",
                table: "ConnectorInfo");

            migrationBuilder.DropColumn(
                name: "syll_front_img",
                table: "ConnectorInfo");
        }
    }
}
