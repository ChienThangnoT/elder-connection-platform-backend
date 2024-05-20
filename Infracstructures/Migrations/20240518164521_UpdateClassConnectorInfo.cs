using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infracstructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClassConnectorInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectorFeedback_Task",
                table: "ConnectorFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Address",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_JobSchedule",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Service",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationProgram_TrainingProgram",
                table: "RegistrationProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Sale",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceType",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceFeedback_Post",
                table: "ServiceFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceFeedback_Service",
                table: "ServiceFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_JobSchedule",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_ServiceFeedback_service_id",
                table: "ServiceFeedback");

            migrationBuilder.DropColumn(
                name: "service_id",
                table: "ServiceFeedback");

            migrationBuilder.AlterColumn<float>(
                name: "wallet_balance_change",
                table: "TransactionHistory",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "transaction_amount",
                table: "TransactionHistory",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "payment_date",
                table: "TransactionHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "TrainingProgram",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "work_date_at",
                table: "Task",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "task_update_at",
                table: "Task",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "job_schedule_id",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Task",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "complete_date",
                table: "Task",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "service_price_per_hour",
                table: "ServiceType",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "rating_stars",
                table: "ServiceFeedback",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "post_id",
                table: "ServiceFeedback",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "ServiceFeedback",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "service_type_id",
                table: "Service",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "sale_id",
                table: "Service",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "rating_avg",
                table: "Service",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "original_price",
                table: "Service",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "final_price",
                table: "Service",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "sale_percent",
                table: "Sale",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "traning_program_id",
                table: "RegistrationProgram",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_completed",
                table: "RegistrationProgram",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "enrollment_date",
                table: "RegistrationProgram",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "start_time",
                table: "Post",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0),
                oldClrType: typeof(TimeOnly),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "service_id",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "salary_after_work",
                table: "Post",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "price",
                table: "Post",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "job_schedule_id",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "address_id",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "send_date",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_read",
                table: "Notification",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "task_process",
                table: "JobSchedule",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                table: "JobSchedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "on_task",
                table: "JobSchedule",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                table: "JobSchedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "send_date",
                table: "ConnectorInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_approved",
                table: "ConnectorInfo",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "task_id",
                table: "ConnectorFeedback",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "rating_stars",
                table: "ConnectorFeedback",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "rating_date",
                table: "ConnectorFeedback",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_rating_status",
                table: "ConnectorFeedback",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthday",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectorFeedback_Task",
                table: "ConnectorFeedback",
                column: "task_id",
                principalTable: "Task",
                principalColumn: "task_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Address",
                table: "Post",
                column: "address_id",
                principalTable: "Address",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_JobSchedule",
                table: "Post",
                column: "job_schedule_id",
                principalTable: "JobSchedule",
                principalColumn: "job_schedule_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Service",
                table: "Post",
                column: "service_id",
                principalTable: "Service",
                principalColumn: "service_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationProgram_TrainingProgram",
                table: "RegistrationProgram",
                column: "traning_program_id",
                principalTable: "TrainingProgram",
                principalColumn: "traning_program_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Sale",
                table: "Service",
                column: "sale_id",
                principalTable: "Sale",
                principalColumn: "sale_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceType",
                table: "Service",
                column: "service_type_id",
                principalTable: "ServiceType",
                principalColumn: "service_type_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceFeedback_Post",
                table: "ServiceFeedback",
                column: "post_id",
                principalTable: "Post",
                principalColumn: "post_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_JobSchedule",
                table: "Task",
                column: "job_schedule_id",
                principalTable: "JobSchedule",
                principalColumn: "job_schedule_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectorFeedback_Task",
                table: "ConnectorFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Address",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_JobSchedule",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Service",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationProgram_TrainingProgram",
                table: "RegistrationProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Sale",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceType",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceFeedback_Post",
                table: "ServiceFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_JobSchedule",
                table: "Task");

            migrationBuilder.AlterColumn<float>(
                name: "wallet_balance_change",
                table: "TransactionHistory",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "transaction_amount",
                table: "TransactionHistory",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "payment_date",
                table: "TransactionHistory",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "TrainingProgram",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "work_date_at",
                table: "Task",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "task_update_at",
                table: "Task",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "job_schedule_id",
                table: "Task",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Task",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "complete_date",
                table: "Task",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<float>(
                name: "service_price_per_hour",
                table: "ServiceType",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "rating_stars",
                table: "ServiceFeedback",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "post_id",
                table: "ServiceFeedback",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "ServiceFeedback",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "service_id",
                table: "ServiceFeedback",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "service_type_id",
                table: "Service",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "sale_id",
                table: "Service",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "rating_avg",
                table: "Service",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "original_price",
                table: "Service",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "final_price",
                table: "Service",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "sale_percent",
                table: "Sale",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "traning_program_id",
                table: "RegistrationProgram",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "is_completed",
                table: "RegistrationProgram",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "enrollment_date",
                table: "RegistrationProgram",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Post",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "start_time",
                table: "Post",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<int>(
                name: "service_id",
                table: "Post",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "salary_after_work",
                table: "Post",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "price",
                table: "Post",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "job_schedule_id",
                table: "Post",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Post",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "address_id",
                table: "Post",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "send_date",
                table: "Notification",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "is_read",
                table: "Notification",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<float>(
                name: "task_process",
                table: "JobSchedule",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                table: "JobSchedule",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "on_task",
                table: "JobSchedule",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                table: "JobSchedule",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "send_date",
                table: "ConnectorInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "is_approved",
                table: "ConnectorInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "task_id",
                table: "ConnectorFeedback",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "rating_stars",
                table: "ConnectorFeedback",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "rating_date",
                table: "ConnectorFeedback",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "is_rating_status",
                table: "ConnectorFeedback",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthday",
                table: "Accounts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceFeedback_service_id",
                table: "ServiceFeedback",
                column: "service_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectorFeedback_Task",
                table: "ConnectorFeedback",
                column: "task_id",
                principalTable: "Task",
                principalColumn: "task_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Address",
                table: "Post",
                column: "address_id",
                principalTable: "Address",
                principalColumn: "address_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_JobSchedule",
                table: "Post",
                column: "job_schedule_id",
                principalTable: "JobSchedule",
                principalColumn: "job_schedule_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Service",
                table: "Post",
                column: "service_id",
                principalTable: "Service",
                principalColumn: "service_id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationProgram_TrainingProgram",
                table: "RegistrationProgram",
                column: "traning_program_id",
                principalTable: "TrainingProgram",
                principalColumn: "traning_program_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Sale",
                table: "Service",
                column: "sale_id",
                principalTable: "Sale",
                principalColumn: "sale_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceType",
                table: "Service",
                column: "service_type_id",
                principalTable: "ServiceType",
                principalColumn: "service_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceFeedback_Post",
                table: "ServiceFeedback",
                column: "post_id",
                principalTable: "Post",
                principalColumn: "post_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceFeedback_Service",
                table: "ServiceFeedback",
                column: "service_id",
                principalTable: "Service",
                principalColumn: "service_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_JobSchedule",
                table: "Task",
                column: "job_schedule_id",
                principalTable: "JobSchedule",
                principalColumn: "job_schedule_id");
        }
    }
}
