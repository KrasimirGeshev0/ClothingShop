using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShop.Infrastructure.Migrations
{
    public partial class ApplicationUserAddBoolIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b785fd5-4718-47e9-aa3f-29787e499a63", true, "AQAAAAEAACcQAAAAEEIin0CcWynDAypMOvDjCLaLFZJWo89aWdcLjur564TuqPEVAeyLGfD9V3mbr8zPew==", "8af96faf-d259-4bd0-9359-7592cb8513aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68cc045d-e343-4162-8e1f-a1ce4e61ec92", true, "AQAAAAEAACcQAAAAEIP1WlxTQ/ECiedUArnoNe6Kacn0i1UfkG6xu+OlG/bMbY2IIbZVwdzsy6aJQkV+vw==", "f5e5c476-4d64-41d9-9b41-4b64e9cf08d4" });


            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Shorts");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Trousers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "415f0424-de60-4ffe-a988-e267825ed52c");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52dc62d8-6ac7-43b0-afb3-01dddb982894", "AQAAAAEAACcQAAAAEAZZM4c+Un9ySDITMjYnM4tUK+GOOPwYkbxWvbwJ3O330XWh02PEn66kB8XBkaIeVQ==", "756e7283-cbcd-444c-8af5-8db630a04010" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cc61f6b-2260-4cde-94d1-db9ba4049a64", "AQAAAAEAACcQAAAAEHQ+TGcOuUx8GKBF3OKplHRYQQKSIW7Ltqnnzzbt5Mlx3K5S1++AMQgh+llNE270RA==", "9bdb2041-94cc-48ec-9d31-03d72d823159" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Hats");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Shorts");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "Jeans" },
                    { 8, "Trousers" }
                });
        }
    }
}
