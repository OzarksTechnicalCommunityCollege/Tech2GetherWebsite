using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tech2Gether_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "event_def",
                columns: table => new
                {
                    event_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    event_type_desc = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_def", x => x.event_type_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "meeting",
                columns: table => new
                {
                    meeting_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    meeting_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meeting", x => x.meeting_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "membership_def",
                columns: table => new
                {
                    mem_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    mem_desc = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membership_def", x => x.mem_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "event_source",
                columns: table => new
                {
                    event_source_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    event_type_id = table.Column<int>(type: "int", nullable: false),
                    event_name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_source", x => x.event_source_id);
                    table.ForeignKey(
                        name: "FK_event_source_event_def_event_type_id",
                        column: x => x.event_type_id,
                        principalTable: "event_def",
                        principalColumn: "event_type_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mem_id = table.Column<int>(type: "int", nullable: true),
                    em_first_name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    em_last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    em_relationship = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    em_phone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_github = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_linkedin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pronouns = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pre_name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_user_membership_def_mem_id",
                        column: x => x.mem_id,
                        principalTable: "membership_def",
                        principalColumn: "mem_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    event_source_id = table.Column<int>(type: "int", nullable: true),
                    event_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    event_end_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.event_id);
                    table.ForeignKey(
                        name: "FK_event_event_source_event_source_id",
                        column: x => x.event_source_id,
                        principalTable: "event_source",
                        principalColumn: "event_source_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    street_1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    street_2 = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    state = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    zip = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.address_id);
                    table.ForeignKey(
                        name: "FK_address_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "attendance",
                columns: table => new
                {
                    attendance_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    meeting_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendance", x => x.attendance_id);
                    table.ForeignKey(
                        name: "FK_attendance_meeting_meeting_id",
                        column: x => x.meeting_id,
                        principalTable: "meeting",
                        principalColumn: "meeting_id");
                    table.ForeignKey(
                        name: "FK_attendance_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "login",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password_hash = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password_salt = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_admin = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    email_verification_token = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email_verification_expires = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    email_is_verified = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    password_reset_token = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password_reset_expires = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_login_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "organization",
                columns: table => new
                {
                    org_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    org_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type_id = table.Column<int>(type: "int", nullable: true),
                    org_phone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address_id = table.Column<int>(type: "int", nullable: true),
                    org_email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization", x => x.org_id);
                    table.ForeignKey(
                        name: "FK_organization_address_address_id",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "address_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "speaker",
                columns: table => new
                {
                    speaker_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    speaker_first_name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    speaker_last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    speaker_linkedin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    speaker_organization = table.Column<int>(type: "int", nullable: true),
                    speaker_title = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_speaker", x => x.speaker_id);
                    table.ForeignKey(
                        name: "FK_speaker_organization_speaker_organization",
                        column: x => x.speaker_organization,
                        principalTable: "organization",
                        principalColumn: "org_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_org",
                columns: table => new
                {
                    user_org_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    graduation_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_org", x => x.user_org_id);
                    table.ForeignKey(
                        name: "FK_user_org_organization_org_id",
                        column: x => x.org_id,
                        principalTable: "organization",
                        principalColumn: "org_id");
                    table.ForeignKey(
                        name: "FK_user_org_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "speaker_meeting",
                columns: table => new
                {
                    speaker_meeting_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    speaker_id = table.Column<int>(type: "int", nullable: true),
                    meeting_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_speaker_meeting", x => x.speaker_meeting_id);
                    table.ForeignKey(
                        name: "FK_speaker_meeting_meeting_meeting_id",
                        column: x => x.meeting_id,
                        principalTable: "meeting",
                        principalColumn: "meeting_id");
                    table.ForeignKey(
                        name: "FK_speaker_meeting_speaker_speaker_id",
                        column: x => x.speaker_id,
                        principalTable: "speaker",
                        principalColumn: "speaker_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "event_team",
                columns: table => new
                {
                    team_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    event_id = table.Column<int>(type: "int", nullable: true),
                    user_team_id = table.Column<int>(type: "int", nullable: true),
                    team_name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_team", x => x.team_id);
                    table.ForeignKey(
                        name: "FK_event_team_event_event_id",
                        column: x => x.event_id,
                        principalTable: "event",
                        principalColumn: "event_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_team",
                columns: table => new
                {
                    user_team_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    team_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    leader = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_team", x => x.user_team_id);
                    table.ForeignKey(
                        name: "FK_user_team_event_team_team_id",
                        column: x => x.team_id,
                        principalTable: "event_team",
                        principalColumn: "team_id");
                    table.ForeignKey(
                        name: "FK_user_team_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "idx_address_user_id",
                table: "address",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "idx_attendance_meeting_id",
                table: "attendance",
                column: "meeting_id");

            migrationBuilder.CreateIndex(
                name: "idx_attendance_user_id",
                table: "attendance",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "idx_event_source_id",
                table: "event",
                column: "event_source_id");

            migrationBuilder.CreateIndex(
                name: "IX_event_source_event_type_id",
                table: "event_source",
                column: "event_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_event_team_event_id",
                table: "event_team",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_event_team_user_team_id",
                table: "event_team",
                column: "user_team_id");

            migrationBuilder.CreateIndex(
                name: "idx_organization_address_id",
                table: "organization",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_speaker_speaker_organization",
                table: "speaker",
                column: "speaker_organization");

            migrationBuilder.CreateIndex(
                name: "IX_speaker_meeting_meeting_id",
                table: "speaker_meeting",
                column: "meeting_id");

            migrationBuilder.CreateIndex(
                name: "IX_speaker_meeting_speaker_id",
                table: "speaker_meeting",
                column: "speaker_id");

            migrationBuilder.CreateIndex(
                name: "idx_user_mem_id",
                table: "user",
                column: "mem_id");

            migrationBuilder.CreateIndex(
                name: "idx_user_org_org_id",
                table: "user_org",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "idx_user_org_user_id",
                table: "user_org",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_team_team_id",
                table: "user_team",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_team_user_id",
                table: "user_team",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_event_team_user_team_user_team_id",
                table: "event_team",
                column: "user_team_id",
                principalTable: "user_team",
                principalColumn: "user_team_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_team_user_user_id",
                table: "user_team");

            migrationBuilder.DropForeignKey(
                name: "FK_event_event_source_event_source_id",
                table: "event");

            migrationBuilder.DropForeignKey(
                name: "FK_event_team_event_event_id",
                table: "event_team");

            migrationBuilder.DropForeignKey(
                name: "FK_event_team_user_team_user_team_id",
                table: "event_team");

            migrationBuilder.DropTable(
                name: "attendance");

            migrationBuilder.DropTable(
                name: "login");

            migrationBuilder.DropTable(
                name: "speaker_meeting");

            migrationBuilder.DropTable(
                name: "user_org");

            migrationBuilder.DropTable(
                name: "meeting");

            migrationBuilder.DropTable(
                name: "speaker");

            migrationBuilder.DropTable(
                name: "organization");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "membership_def");

            migrationBuilder.DropTable(
                name: "event_source");

            migrationBuilder.DropTable(
                name: "event_def");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "user_team");

            migrationBuilder.DropTable(
                name: "event_team");
        }
    }
}
