using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShop.Infrastructure.Migrations
{
    public partial class categorySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a51a4abb-3665-4f7d-bd2b-861fb07edf7e", "AQAAAAEAACcQAAAAED7xdRqceJxbs9oSZylxqROr0DAsAILdBQXRLE05nWfVMc+3lOPLLJCORuFLxfBvuQ==", "4c1465b4-0620-4108-80ea-73e9fa6ed4da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81cca9ab-2137-4ad3-aac3-ab8c8b3e6ca7", "AQAAAAEAACcQAAAAENs7JXViGlKqypLqx+NII7xK5TaGCcDqoYR1tQa9QhPjJW0YqYvDOMn6WVzB2QAi8w==", "6b63f998-e568-44ee-9913-d2542d74c38e" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Jeans" },
                    { 5, "Jeans" },
                    { 6, "Hats" },
                    { 7, "Shorts" },
                    { 8, "Trousers" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca8ccc30-3cf8-470e-ab83-4bd365d9f976", "AQAAAAEAACcQAAAAEO+k7gz3hTFowQcxZgT7itq/AYayZxN1P80unaqQCxH23EXjvibDKxsrIQybQdWQFA==", "61a70e6f-c1ae-4fee-9bcb-90421958d44d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef97eb8a-b374-4b52-9011-d0157724cdb5", "AQAAAAEAACcQAAAAEOVcHXEFE3uGk/fExJNM2dhktM26axuhJw4lPuUVLjhhN1AZlPXJdnuAU5m6u0cLKA==", "a4ef5c6c-e2e1-47c2-8fa8-dc1bd0631bb3" });
        }
    }
}
