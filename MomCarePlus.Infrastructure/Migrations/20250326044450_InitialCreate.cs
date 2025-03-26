using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MomCarePlus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UserType = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PregnancyProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpectedDueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FirstDayOfLastMenstrualPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PregnancyWeek = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    StartWeight = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    CurrentWeight = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    BloodType = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    RhFactor = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    MedicalHistory = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregnancyProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PregnancyProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthTrackings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PregnancyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrackingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    BloodPressureSystolic = table.Column<int>(type: "integer", nullable: true),
                    BloodPressureDiastolic = table.Column<int>(type: "integer", nullable: true),
                    Symptoms = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MentalHealthScore = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthTrackings_PregnancyProfiles_PregnancyProfileId",
                        column: x => x.PregnancyProfileId,
                        principalTable: "PregnancyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthTrackings_PregnancyProfileId",
                table: "HealthTrackings",
                column: "PregnancyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyProfiles_UserId",
                table: "PregnancyProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthTrackings");

            migrationBuilder.DropTable(
                name: "PregnancyProfiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
