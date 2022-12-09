using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShop.Infrastructure.Migrations
{
    public partial class IsAvailableToTableBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8823ceef-af73-47fc-a997-66d5d07482d5", "AQAAAAEAACcQAAAAEBJwXftUiQrx3asO3r2mGkxUhg5Rcjpg3TWTxPzDtLcMfrL4Lub3CLIEmK1h/uUK7w==", "ab6fadd4-7464-4c1c-ac64-c77d703e87da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c8bc3b9-0f08-4e77-8b8e-0d7c94c80071", "AQAAAAEAACcQAAAAEPn/ZUeut7/wzih/uZgMVOwcMZ6t0BZXsLWFfzHu/jT0h5hcFUsCjoE58Dkx//YYGg==", "4e49789c-4d74-41c6-b31d-b0f35ee2f409" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsAvailable",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Brands");

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
        }
    }
}
