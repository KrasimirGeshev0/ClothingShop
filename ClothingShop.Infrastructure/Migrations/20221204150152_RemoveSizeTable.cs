using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShop.Infrastructure.Migrations
{
    public partial class RemoveSizeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_ClothesSizesQuantities_ClothSizesQuantitiesId",
                table: "Clothes");

            migrationBuilder.DropTable(
                name: "ClothesSizesQuantities");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_ClothSizesQuantitiesId",
                table: "Clothes");

            migrationBuilder.RenameColumn(
                name: "ClothSizesQuantitiesId",
                table: "Clothes",
                newName: "Quantity");

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

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Quantity" },
                values: new object[] { "https://image.goat.com/transform/v1/attachments/product_template_additional_pictures/images/052/170/816/original/746090_01.jpg.jpeg?action=crop&width=750", 10 });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "Quantity" },
                values: new object[] { "https://img01.ztat.net/article/spp-media-p1/20f877b0dfd33bc99f742bf8a7e57db4/aa07fae097284ea589a1665965c73678.jpg?imwidth=1800", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Clothes",
                newName: "ClothSizesQuantitiesId");

            migrationBuilder.CreateTable(
                name: "ClothesSizesQuantities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LQuantity = table.Column<int>(type: "int", nullable: false),
                    MQuantity = table.Column<int>(type: "int", nullable: false),
                    SQuantity = table.Column<int>(type: "int", nullable: false),
                    XlQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesSizesQuantities", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bf4ad23-c7a8-4706-9723-ef764f51831a", "AQAAAAEAACcQAAAAEEv5OD9wF+jgjCHVRkKl+i43zFeKm/kttaiNoC7YXKJt7PqE87FbA4iVLYsbDUn0ag==", "5f096fbe-475d-4eb0-ae28-9e9b1fa445d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88c09e99-51f5-4e68-886d-73cddf11804f", "AQAAAAEAACcQAAAAECN2JlsXlrqcs3z9l2S62oVr/p8fvtqTFsM4pe9Vb9iqy8yhLGGAde5pPbDHZ6EYug==", "5037ca0a-1eb1-4e16-9d93-440fa523d87d" });

            migrationBuilder.InsertData(
                table: "ClothesSizesQuantities",
                columns: new[] { "Id", "LQuantity", "MQuantity", "SQuantity", "XlQuantity" },
                values: new object[,]
                {
                    { 1, 2, 5, 3, 1 },
                    { 2, 2, 5, 3, 1 },
                    { 3, 1, 2, 4, 0 }
                });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClothSizesQuantitiesId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClothSizesQuantitiesId", "ImageUrl" },
                values: new object[] { 2, "https://incorporatedstyle.com/content/uploads/supreme-x-nike-ss21-black-puffy-jacket-550x459.jpg" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClothSizesQuantitiesId", "ImageUrl" },
                values: new object[] { 3, "https://incorporatedstyle.com/content/uploads/supreme-x-nike-ss21-black-puffy-jacket-550x459.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_ClothSizesQuantitiesId",
                table: "Clothes",
                column: "ClothSizesQuantitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_ClothesSizesQuantities_ClothSizesQuantitiesId",
                table: "Clothes",
                column: "ClothSizesQuantitiesId",
                principalTable: "ClothesSizesQuantities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
