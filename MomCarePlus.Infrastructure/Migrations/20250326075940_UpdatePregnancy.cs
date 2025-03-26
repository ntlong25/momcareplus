using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MomCarePlus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePregnancy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthTrackings");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "PregnancyProfiles");

            migrationBuilder.DropColumn(
                name: "CurrentWeight",
                table: "PregnancyProfiles");

            migrationBuilder.DropColumn(
                name: "ExpectedDueDate",
                table: "PregnancyProfiles");

            migrationBuilder.DropColumn(
                name: "FirstDayOfLastMenstrualPeriod",
                table: "PregnancyProfiles");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "PregnancyProfiles");

            migrationBuilder.DropColumn(
                name: "MedicalHistory",
                table: "PregnancyProfiles");

            migrationBuilder.DropColumn(
                name: "RhFactor",
                table: "PregnancyProfiles");

            migrationBuilder.DropColumn(
                name: "StartWeight",
                table: "PregnancyProfiles");

            migrationBuilder.RenameColumn(
                name: "PregnancyWeek",
                table: "PregnancyProfiles",
                newName: "Stage");

            migrationBuilder.AddColumn<int>(
                name: "CurrentWeek",
                table: "PregnancyProfiles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedDeliveryDate",
                table: "PregnancyProfiles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderPreference",
                table: "PregnancyProfiles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPlanningPregnancy",
                table: "PregnancyProfiles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPeriodDate",
                table: "PregnancyProfiles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "PregnancyProfiles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PregnancyAdvices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Stage = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    IsRecommended = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregnancyAdvices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PregnancyMilestones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PregnancyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregnancyMilestones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PregnancyMilestones_PregnancyProfiles_PregnancyProfileId",
                        column: x => x.PregnancyProfileId,
                        principalTable: "PregnancyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyMilestones_PregnancyProfileId",
                table: "PregnancyMilestones",
                column: "PregnancyProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PregnancyAdvices");

            migrationBuilder.DropTable(
                name: "PregnancyMilestones");

            migrationBuilder.DropColumn(
                name: "CurrentWeek",
                table: "PregnancyProfiles");

            migrationBuilder.DropColumn(
                name: "ExpectedDeliveryDate",
                table: "PregnancyProfiles");

            migrationBuilder.DropColumn(
                name: "GenderPreference",
                table: "PregnancyProfiles");

            migrationBuilder.DropColumn(
                name: "IsPlanningPregnancy",
                table: "PregnancyProfiles");

            migrationBuilder.DropColumn(
                name: "LastPeriodDate",
                table: "PregnancyProfiles");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PregnancyProfiles");

            migrationBuilder.RenameColumn(
                name: "Stage",
                table: "PregnancyProfiles",
                newName: "PregnancyWeek");

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "PregnancyProfiles",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentWeight",
                table: "PregnancyProfiles",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedDueDate",
                table: "PregnancyProfiles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstDayOfLastMenstrualPeriod",
                table: "PregnancyProfiles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "PregnancyProfiles",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "MedicalHistory",
                table: "PregnancyProfiles",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RhFactor",
                table: "PregnancyProfiles",
                type: "character varying(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "StartWeight",
                table: "PregnancyProfiles",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "HealthTrackings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PregnancyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodPressureDiastolic = table.Column<int>(type: "integer", nullable: true),
                    BloodPressureSystolic = table.Column<int>(type: "integer", nullable: true),
                    MentalHealthScore = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Symptoms = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    TrackingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false)
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
        }
    }
}
