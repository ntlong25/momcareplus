using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MomCarePlus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PregnancyAdviceCategoryAdvices",
                keyColumns: new[] { "AdvicesId", "CategoriesId" },
                keyValues: new object[] { new Guid("0142abd4-2e98-455a-a88a-3a5a99042479"), new Guid("e5b273d1-851e-44db-bf7c-e8f8a162e501") });

            migrationBuilder.DeleteData(
                table: "PregnancyAdviceCategoryAdvices",
                keyColumns: new[] { "AdvicesId", "CategoriesId" },
                keyValues: new object[] { new Guid("27e27fa0-d3a4-4e34-a385-1a30c943abd1"), new Guid("2aab5137-91b6-4399-b461-d82c834c2483") });

            migrationBuilder.DeleteData(
                table: "PregnancyAdviceCategoryAdvices",
                keyColumns: new[] { "AdvicesId", "CategoriesId" },
                keyValues: new object[] { new Guid("f2d7438b-ba2d-45ac-b71e-72cc87b629de"), new Guid("9fce37c8-2a5f-446d-aa24-ac11f1ac746c") });

            migrationBuilder.DeleteData(
                table: "PregnancyAdviceTagAdvices",
                keyColumns: new[] { "AdvicesId", "TagsId" },
                keyValues: new object[] { new Guid("0142abd4-2e98-455a-a88a-3a5a99042479"), new Guid("db09bb37-b99b-4719-afcc-5485c04a4600") });

            migrationBuilder.DeleteData(
                table: "PregnancyAdviceTagAdvices",
                keyColumns: new[] { "AdvicesId", "TagsId" },
                keyValues: new object[] { new Guid("27e27fa0-d3a4-4e34-a385-1a30c943abd1"), new Guid("c2fffc68-3cbb-40d5-bcc7-1c2d2bd64093") });

            migrationBuilder.DeleteData(
                table: "PregnancyAdviceTagAdvices",
                keyColumns: new[] { "AdvicesId", "TagsId" },
                keyValues: new object[] { new Guid("f2d7438b-ba2d-45ac-b71e-72cc87b629de"), new Guid("9ca6b635-7c46-4376-bf35-38ce02b0c719") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4be453ca-ccc5-4022-a55a-f71bad7e5e6c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("598c101b-de2e-4cb6-bf16-933711568238"));

            migrationBuilder.DeleteData(
                table: "PregnancyAdviceCategories",
                keyColumn: "Id",
                keyValue: new Guid("2aab5137-91b6-4399-b461-d82c834c2483"));

            migrationBuilder.DeleteData(
                table: "PregnancyAdviceCategories",
                keyColumn: "Id",
                keyValue: new Guid("9fce37c8-2a5f-446d-aa24-ac11f1ac746c"));

            migrationBuilder.DeleteData(
                table: "PregnancyAdviceCategories",
                keyColumn: "Id",
                keyValue: new Guid("e5b273d1-851e-44db-bf7c-e8f8a162e501"));

            migrationBuilder.DeleteData(
                table: "PregnancyAdviceTags",
                keyColumn: "Id",
                keyValue: new Guid("9ca6b635-7c46-4376-bf35-38ce02b0c719"));

            migrationBuilder.DeleteData(
                table: "PregnancyAdviceTags",
                keyColumn: "Id",
                keyValue: new Guid("c2fffc68-3cbb-40d5-bcc7-1c2d2bd64093"));

            migrationBuilder.DeleteData(
                table: "PregnancyAdviceTags",
                keyColumn: "Id",
                keyValue: new Guid("db09bb37-b99b-4719-afcc-5485c04a4600"));

            migrationBuilder.DeleteData(
                table: "PregnancyAdvices",
                keyColumn: "Id",
                keyValue: new Guid("0142abd4-2e98-455a-a88a-3a5a99042479"));

            migrationBuilder.DeleteData(
                table: "PregnancyAdvices",
                keyColumn: "Id",
                keyValue: new Guid("27e27fa0-d3a4-4e34-a385-1a30c943abd1"));

            migrationBuilder.DeleteData(
                table: "PregnancyAdvices",
                keyColumn: "Id",
                keyValue: new Guid("f2d7438b-ba2d-45ac-b71e-72cc87b629de"));
        }
    }
}
