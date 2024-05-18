using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infracstructures.Migrations
{
    /// <inheritdoc />
    public partial class InitDBContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConnectorInfo",
                columns: table => new
                {
                    connector_infor_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    social_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    send_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_approved = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cccd_front_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cccd_behind_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gxnhk_img = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectorInfo", x => x.connector_infor_id);
                });

            migrationBuilder.CreateTable(
                name: "JobSchedule",
                columns: table => new
                {
                    job_schedule_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location_work = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    task_process = table.Column<float>(type: "real", nullable: true),
                    task_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    on_task = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSchedule", x => x.job_schedule_id);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    sale_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sale_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sale_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sale_percent = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.sale_id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    service_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_type_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    service_type_hours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    service_price_per_hour = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.service_type_id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProgram",
                columns: table => new
                {
                    traning_program_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    traning_program_level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    traning_program_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    traning_program_content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    traning_program_duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingProgram", x => x.traning_program_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    connector_infor_id = table.Column<int>(type: "int", nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profile_picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sex = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    status = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    device_token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    refresh_token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    refresh_token_expiry_time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wallet_balance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avg_rating = table.Column<float>(type: "real", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_ConnectorInfo",
                        column: x => x.connector_infor_id,
                        principalTable: "ConnectorInfo",
                        principalColumn: "connector_infor_id");
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    service_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_type_id = table.Column<int>(type: "int", nullable: true),
                    sale_id = table.Column<int>(type: "int", nullable: true),
                    original_price = table.Column<float>(type: "real", nullable: true),
                    final_price = table.Column<float>(type: "real", nullable: true),
                    service_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    service_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating_avg = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.service_id);
                    table.ForeignKey(
                        name: "FK_Service_Sale",
                        column: x => x.sale_id,
                        principalTable: "Sale",
                        principalColumn: "sale_id");
                    table.ForeignKey(
                        name: "FK_Service_ServiceType",
                        column: x => x.service_type_id,
                        principalTable: "ServiceType",
                        principalColumn: "service_type_id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    address_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    home_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.address_id);
                    table.ForeignKey(
                        name: "FK_Address_Account",
                        column: x => x.account_id,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteList",
                columns: table => new
                {
                    favorite_list_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    connector_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteList", x => x.favorite_list_id);
                    table.ForeignKey(
                        name: "FK_FavoriteList_Account",
                        column: x => x.customer_id,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    notification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    send_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_read = table.Column<bool>(type: "bit", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    action = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.notification_id);
                    table.ForeignKey(
                        name: "FK_Notification_Account",
                        column: x => x.account_id,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RegistrationProgram",
                columns: table => new
                {
                    registration_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    traning_program_id = table.Column<int>(type: "int", nullable: true),
                    connector_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    enrollment_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_completed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationProgram", x => x.registration_id);
                    table.ForeignKey(
                        name: "FK_RegistrationProgram_Account",
                        column: x => x.connector_id,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistrationProgram_TrainingProgram",
                        column: x => x.traning_program_id,
                        principalTable: "TrainingProgram",
                        principalColumn: "traning_program_id");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    task_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    job_schedule_id = table.Column<int>(type: "int", nullable: true),
                    connector_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    work_date_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    task_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    complete_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    task_update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    task_update_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.task_id);
                    table.ForeignKey(
                        name: "FK_Task_Account",
                        column: x => x.connector_id,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Task_JobSchedule",
                        column: x => x.job_schedule_id,
                        principalTable: "JobSchedule",
                        principalColumn: "job_schedule_id");
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistory",
                columns: table => new
                {
                    transaction_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    account_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    transaction_amount = table.Column<float>(type: "real", nullable: true),
                    wallet_balance_change = table.Column<float>(type: "real", nullable: true),
                    payment_method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    transaction_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    currency_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    transaction_type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistory", x => x.transaction_id);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Account",
                        column: x => x.account_id,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    post_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_id = table.Column<int>(type: "int", nullable: true),
                    job_schedule_id = table.Column<int>(type: "int", nullable: true),
                    customer_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    address_id = table.Column<int>(type: "int", nullable: true),
                    is_priority_favorite_connector = table.Column<bool>(type: "bit", nullable: true),
                    post_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    post_status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    start_time = table.Column<TimeOnly>(type: "time", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    price = table.Column<float>(type: "real", nullable: true),
                    salary_after_work = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.post_id);
                    table.ForeignKey(
                        name: "FK_Post_Account",
                        column: x => x.customer_id,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_Address",
                        column: x => x.address_id,
                        principalTable: "Address",
                        principalColumn: "address_id");
                    table.ForeignKey(
                        name: "FK_Post_JobSchedule",
                        column: x => x.job_schedule_id,
                        principalTable: "JobSchedule",
                        principalColumn: "job_schedule_id");
                    table.ForeignKey(
                        name: "FK_Post_Service",
                        column: x => x.service_id,
                        principalTable: "Service",
                        principalColumn: "service_id");
                });

            migrationBuilder.CreateTable(
                name: "ConnectorFeedback",
                columns: table => new
                {
                    rating_connector_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    task_id = table.Column<int>(type: "int", nullable: true),
                    customer_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    connector_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    is_rating_status = table.Column<bool>(type: "bit", nullable: true),
                    rating_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rating_stars = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectorFeedback", x => x.rating_connector_id);
                    table.ForeignKey(
                        name: "FK_ConnectorFeedback_Task",
                        column: x => x.task_id,
                        principalTable: "Task",
                        principalColumn: "task_id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceFeedback",
                columns: table => new
                {
                    service_feedback_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_id = table.Column<int>(type: "int", nullable: true),
                    post_id = table.Column<int>(type: "int", nullable: true),
                    customer_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    feedback_content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating_stars = table.Column<int>(type: "int", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceFeedback", x => x.service_feedback_id);
                    table.ForeignKey(
                        name: "FK_ServiceFeedback_Account",
                        column: x => x.customer_id,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceFeedback_Post",
                        column: x => x.post_id,
                        principalTable: "Post",
                        principalColumn: "post_id");
                    table.ForeignKey(
                        name: "FK_ServiceFeedback_Service",
                        column: x => x.service_id,
                        principalTable: "Service",
                        principalColumn: "service_id");
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Accounts",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_connector_infor_id",
                table: "Accounts",
                column: "connector_infor_id");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Accounts",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_account_id",
                table: "Address",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectorFeedback_task_id",
                table: "ConnectorFeedback",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteList_customer_id",
                table: "FavoriteList",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_account_id",
                table: "Notification",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_address_id",
                table: "Post",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_customer_id",
                table: "Post",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_job_schedule_id",
                table: "Post",
                column: "job_schedule_id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_service_id",
                table: "Post",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationProgram_connector_id",
                table: "RegistrationProgram",
                column: "connector_id");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationProgram_traning_program_id",
                table: "RegistrationProgram",
                column: "traning_program_id");

            migrationBuilder.CreateIndex(
                name: "IX_Service_sale_id",
                table: "Service",
                column: "sale_id");

            migrationBuilder.CreateIndex(
                name: "IX_Service_service_type_id",
                table: "Service",
                column: "service_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceFeedback_customer_id",
                table: "ServiceFeedback",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceFeedback_post_id",
                table: "ServiceFeedback",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceFeedback_service_id",
                table: "ServiceFeedback",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_Task_connector_id",
                table: "Task",
                column: "connector_id");

            migrationBuilder.CreateIndex(
                name: "IX_Task_job_schedule_id",
                table: "Task",
                column: "job_schedule_id");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_account_id",
                table: "TransactionHistory",
                column: "account_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ConnectorFeedback");

            migrationBuilder.DropTable(
                name: "FavoriteList");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "RegistrationProgram");

            migrationBuilder.DropTable(
                name: "ServiceFeedback");

            migrationBuilder.DropTable(
                name: "TransactionHistory");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "TrainingProgram");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "JobSchedule");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropTable(
                name: "ConnectorInfo");
        }
    }
}
