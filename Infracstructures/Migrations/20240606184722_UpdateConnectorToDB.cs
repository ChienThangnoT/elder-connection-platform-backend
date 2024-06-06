using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infracstructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConnectorToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Account",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_connector_id",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "connector_id",
                table: "Task");

            migrationBuilder.AddColumn<string>(
                name: "connector_id",
                table: "JobSchedule",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSchedule_connector_id",
                table: "JobSchedule",
                column: "connector_id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSchedule_Account",
                table: "JobSchedule",
                column: "connector_id",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSchedule_Account",
                table: "JobSchedule");

            migrationBuilder.DropIndex(
                name: "IX_JobSchedule_connector_id",
                table: "JobSchedule");

            migrationBuilder.DropColumn(
                name: "connector_id",
                table: "JobSchedule");

            migrationBuilder.AddColumn<string>(
                name: "connector_id",
                table: "Task",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_connector_id",
                table: "Task",
                column: "connector_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Account",
                table: "Task",
                column: "connector_id",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
