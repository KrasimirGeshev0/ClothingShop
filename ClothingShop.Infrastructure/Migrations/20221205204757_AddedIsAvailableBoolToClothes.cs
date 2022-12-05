using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShop.Infrastructure.Migrations
{
    public partial class AddedIsAvailableBoolToClothes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Clothes",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsAvailable",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Clothes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d613370b-286d-4b48-aff3-e5b134a3b9a7", "AQAAAAEAACcQAAAAEEqZjlyriyhGdUN2b2QY0H7NXMzYnZ0rcNRUtmDIJRmbTNkaIy7qGYPISl+bTqJwRA==", "1f3f077f-70a2-4783-b5d5-721703461e31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dcbec54-b8a2-4bd4-852c-4543d7a941a2", "AQAAAAEAACcQAAAAEIGlnJvq/issTSoyZWud0U7QP0UUel7up3ZABm4LrSD4cuAZYtOIvitzHfpn1avUlQ==", "3c1d5d6e-c526-49ee-ba68-e77597fb34b1" });
        }
    }
}
