using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MomCarePlus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PregnancyAdviceCategoryAdvices");

            migrationBuilder.DropTable(
                name: "PregnancyAdviceTagAdvices");

            migrationBuilder.DropTable(
                name: "PregnancyMilestones");

            migrationBuilder.DropTable(
                name: "PregnancyAdviceCategories");

            migrationBuilder.DropTable(
                name: "PregnancyAdviceTags");

            migrationBuilder.DropTable(
                name: "PregnancyAdvices");

            migrationBuilder.DropTable(
                name: "PregnancyProfiles");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4be453ca-ccc5-4022-a55a-f71bad7e5e6c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("598c101b-de2e-4cb6-bf16-933711568238"));

            migrationBuilder.AddColumn<string>(
                name: "PasswordResetToken",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordResetTokenExpiry",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DateOfBirth", "Email", "FullName", "PasswordHash", "PasswordResetToken", "PasswordResetTokenExpiry", "PhoneNumber", "UpdatedAt", "UserType" },
                values: new object[,]
                {
                    { new Guid("42fa8a15-1338-4845-9588-ace64b7c788b"), new DateTime(2025, 3, 28, 6, 50, 27, 507, DateTimeKind.Utc).AddTicks(6950), null, "expert@momcareplus.com", "Expert User", "CerbEAri0Xh/RX2POYhbUZ0KSwuahTEIikkLwj6afj4=", null, null, null, null, 3 },
                    { new Guid("e3c95794-9ea7-43cc-b9c1-c38fe091e569"), new DateTime(2025, 3, 28, 6, 50, 27, 507, DateTimeKind.Utc).AddTicks(6900), null, "admin@momcareplus.com", "Admin User", "6G94qKPK8LYNjnTllCqm2G3BUM08AzOK7yW30tfjrMc=", null, null, null, null, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("42fa8a15-1338-4845-9588-ace64b7c788b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3c95794-9ea7-43cc-b9c1-c38fe091e569"));

            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordResetTokenExpiry",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "PregnancyAdviceCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregnancyAdviceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PregnancyAdvices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRecommended = table.Column<bool>(type: "boolean", nullable: false),
                    Stage = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregnancyAdvices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PregnancyAdviceTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregnancyAdviceTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PregnancyProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CurrentWeek = table.Column<int>(type: "integer", nullable: true),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GenderPreference = table.Column<int>(type: "integer", nullable: true),
                    IsPlanningPregnancy = table.Column<bool>(type: "boolean", nullable: false),
                    LastPeriodDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Stage = table.Column<int>(type: "integer", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "PregnancyMilestones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PregnancyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
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
                    table.ForeignKey(
                        name: "FK_PregnancyMilestones_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PregnancyAdviceCategories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2aab5137-91b6-4399-b461-d82c834c2483"), new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6210), "Các bài tập an toàn cho mẹ bầu", "Tập thể dục", null },
                    { new Guid("9fce37c8-2a5f-446d-aa24-ac11f1ac746c"), new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6210), "Các lời khuyên về dinh dưỡng cho mẹ bầu", "Dinh dưỡng", null },
                    { new Guid("e5b273d1-851e-44db-bf7c-e8f8a162e501"), new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6220), "Các lời khuyên về sức khỏe cho mẹ bầu", "Sức khỏe", null }
                });

            migrationBuilder.InsertData(
                table: "PregnancyAdviceTags",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9ca6b635-7c46-4376-bf35-38ce02b0c719"), new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6240), "Quan trọng", null },
                    { new Guid("c2fffc68-3cbb-40d5-bcc7-1c2d2bd64093"), new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6250), "Khẩn cấp", null },
                    { new Guid("db09bb37-b99b-4719-afcc-5485c04a4600"), new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6250), "Tham khảo", null }
                });

            migrationBuilder.InsertData(
                table: "PregnancyAdvices",
                columns: new[] { "Id", "Content", "CreatedAt", "IsRecommended", "Stage", "Title", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0142abd4-2e98-455a-a88a-3a5a99042479"), "Việc chuẩn bị tâm lý trước khi sinh rất quan trọng...", new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6310), true, 3, "Chuẩn bị tâm lý trước khi sinh", 4, null },
                    { new Guid("27e27fa0-d3a4-4e34-a385-1a30c943abd1"), "Các bài tập như đi bộ, bơi lội, yoga là những lựa chọn an toàn cho mẹ bầu...", new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6300), true, 2, "Bài tập an toàn cho mẹ bầu", 1, null },
                    { new Guid("f2d7438b-ba2d-45ac-b71e-72cc87b629de"), "Trong tam cá nguyệt đầu, mẹ bầu nên bổ sung đầy đủ axit folic, sắt và canxi...", new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6300), true, 1, "Dinh dưỡng trong tam cá nguyệt đầu", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DateOfBirth", "Email", "FullName", "PasswordHash", "PhoneNumber", "UpdatedAt", "UserType" },
                values: new object[,]
                {
                    { new Guid("4be453ca-ccc5-4022-a55a-f71bad7e5e6c"), new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6130), null, "expert@momcareplus.com", "Expert User", "CerbEAri0Xh/RX2POYhbUZ0KSwuahTEIikkLwj6afj4=", null, null, 3 },
                    { new Guid("598c101b-de2e-4cb6-bf16-933711568238"), new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6110), null, "admin@momcareplus.com", "Admin User", "6G94qKPK8LYNjnTllCqm2G3BUM08AzOK7yW30tfjrMc=", null, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "PregnancyAdviceCategoryAdvices",
                columns: new[] { "AdvicesId", "CategoriesId" },
                values: new object[,]
                {
                    { new Guid("0142abd4-2e98-455a-a88a-3a5a99042479"), new Guid("e5b273d1-851e-44db-bf7c-e8f8a162e501") },
                    { new Guid("27e27fa0-d3a4-4e34-a385-1a30c943abd1"), new Guid("2aab5137-91b6-4399-b461-d82c834c2483") },
                    { new Guid("f2d7438b-ba2d-45ac-b71e-72cc87b629de"), new Guid("9fce37c8-2a5f-446d-aa24-ac11f1ac746c") }
                });

            migrationBuilder.InsertData(
                table: "PregnancyAdviceTagAdvices",
                columns: new[] { "AdvicesId", "TagsId" },
                values: new object[,]
                {
                    { new Guid("0142abd4-2e98-455a-a88a-3a5a99042479"), new Guid("db09bb37-b99b-4719-afcc-5485c04a4600") },
                    { new Guid("27e27fa0-d3a4-4e34-a385-1a30c943abd1"), new Guid("c2fffc68-3cbb-40d5-bcc7-1c2d2bd64093") },
                    { new Guid("f2d7438b-ba2d-45ac-b71e-72cc87b629de"), new Guid("9ca6b635-7c46-4376-bf35-38ce02b0c719") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyAdviceCategoryAdvices_CategoriesId",
                table: "PregnancyAdviceCategoryAdvices",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyAdvices_Stage",
                table: "PregnancyAdvices",
                column: "Stage");

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyAdvices_Type",
                table: "PregnancyAdvices",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyAdviceTagAdvices_TagsId",
                table: "PregnancyAdviceTagAdvices",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyMilestones_DueDate",
                table: "PregnancyMilestones",
                column: "DueDate");

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyMilestones_PregnancyProfileId",
                table: "PregnancyMilestones",
                column: "PregnancyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyMilestones_UserId",
                table: "PregnancyMilestones",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyProfiles_UserId",
                table: "PregnancyProfiles",
                column: "UserId",
                unique: true);
        }
    }
}
