using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShop.Infrastructure.Migrations
{
    public partial class sellerIdToClothes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Clothes",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Clothes");

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
        }
    }
}
