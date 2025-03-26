using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MomCarePlus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePregnancyRelational : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PregnancyProfiles_UserId",
                table: "PregnancyProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyProfiles_UserId",
                table: "PregnancyProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyMilestones_DueDate",
                table: "PregnancyMilestones",
                column: "DueDate");

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyAdvices_Stage",
                table: "PregnancyAdvices",
                column: "Stage");

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyAdvices_Type",
                table: "PregnancyAdvices",
                column: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PregnancyProfiles_UserId",
                table: "PregnancyProfiles");

            migrationBuilder.DropIndex(
                name: "IX_PregnancyMilestones_DueDate",
                table: "PregnancyMilestones");

            migrationBuilder.DropIndex(
                name: "IX_PregnancyAdvices_Stage",
                table: "PregnancyAdvices");

            migrationBuilder.DropIndex(
                name: "IX_PregnancyAdvices_Type",
                table: "PregnancyAdvices");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyProfiles_UserId",
                table: "PregnancyProfiles",
                column: "UserId");
        }
    }
}
