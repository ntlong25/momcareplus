using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MomCarePlus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FinalSprint1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "PregnancyMilestones",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PregnancyAdviceCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregnancyAdviceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PregnancyAdviceTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregnancyAdviceTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PregnancyAdviceCategoryAdvices",
                columns: table => new
                {
                    AdvicesId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregnancyAdviceCategoryAdvices", x => new { x.AdvicesId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_PregnancyAdviceCategoryAdvices_PregnancyAdviceCategories_Ca~",
                        column: x => x.CategoriesId,
                        principalTable: "PregnancyAdviceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PregnancyAdviceCategoryAdvices_PregnancyAdvices_AdvicesId",
                        column: x => x.AdvicesId,
                        principalTable: "PregnancyAdvices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PregnancyAdviceTagAdvices",
                columns: table => new
                {
                    AdvicesId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregnancyAdviceTagAdvices", x => new { x.AdvicesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PregnancyAdviceTagAdvices_PregnancyAdviceTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "PregnancyAdviceTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PregnancyAdviceTagAdvices_PregnancyAdvices_AdvicesId",
                        column: x => x.AdvicesId,
                        principalTable: "PregnancyAdvices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyMilestones_UserId",
                table: "PregnancyMilestones",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyAdviceCategoryAdvices_CategoriesId",
                table: "PregnancyAdviceCategoryAdvices",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyAdviceTagAdvices_TagsId",
                table: "PregnancyAdviceTagAdvices",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PregnancyMilestones_Users_UserId",
                table: "PregnancyMilestones",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PregnancyMilestones_Users_UserId",
                table: "PregnancyMilestones");

            migrationBuilder.DropTable(
                name: "PregnancyAdviceCategoryAdvices");

            migrationBuilder.DropTable(
                name: "PregnancyAdviceTagAdvices");

            migrationBuilder.DropTable(
                name: "PregnancyAdviceCategories");

            migrationBuilder.DropTable(
                name: "PregnancyAdviceTags");

            migrationBuilder.DropIndex(
                name: "IX_PregnancyMilestones_UserId",
                table: "PregnancyMilestones");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PregnancyMilestones");
        }
    }
}
