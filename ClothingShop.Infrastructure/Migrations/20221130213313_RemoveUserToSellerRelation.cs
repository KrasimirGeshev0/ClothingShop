using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShop.Infrastructure.Migrations
{
    public partial class RemoveUserToSellerRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Sellers_SellerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SellerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "ac09644c-ad85-4f3c-9496-3233b4afbaf9", "user@mail.com", false, false, null, "USER@MAIL.COM", "NORMALUSER", "AQAAAAEAACcQAAAAEJcEt1WehyzYBfVNAzL+BA84Bxb19p/kQtRD0LR2JIlNqXb3G8jbHK5chgU/JC93iA==", null, false, "a2e196eb-87de-4ca3-a542-56eb17e441c8", false, "NormalUser" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dea12856-c198-4129-b3f3-b893d8395082", 0, "53a94ed3-f3fd-44b8-9da6-12dc77e265d2", "seller@mail.com", false, false, null, "SELLER@MAIL.COM", "SELLERUSER", "AQAAAAEAACcQAAAAEMXyprs1UK/mOgI5aLufg0gf5+bZlxtYoFzoagis9apiEfC92vl0dr5hqwVuBBGnpg==", null, false, "ab2da260-66bd-4aea-9580-cf75f1723d51", false, "SellerUser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SellerId",
                table: "AspNetUsers",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Sellers_SellerId",
                table: "AspNetUsers",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id");
        }
    }
}
