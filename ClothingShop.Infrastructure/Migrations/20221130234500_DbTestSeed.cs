using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShop.Infrastructure.Migrations
{
    public partial class DbTestSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_ClothesSizesQuantities_SizesQuantities",
                table: "Clothes");

            migrationBuilder.RenameColumn(
                name: "SizesQuantities",
                table: "Clothes",
                newName: "ClothSizesQuantitiesId");

            migrationBuilder.RenameIndex(
                name: "IX_Clothes_SizesQuantities",
                table: "Clothes",
                newName: "IX_Clothes_ClothSizesQuantitiesId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clothes",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                table: "Brands",
                columns: new[] { "Id", "Logo", "Name" },
                values: new object[,]
                {
                    { 1, "https://1000logos.net/wp-content/uploads/2017/05/Symbol-North-Face.jpg", "The North Face" },
                    { 2, "https://upload.wikimedia.org/wikipedia/commons/3/36/Logo_nike_principal.jpg", "Nike" },
                    { 3, "https://1000logos.net/wp-content/uploads/2019/06/Adidas-Logo-1991.jpg", "Addidas" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Jackets" },
                    { 2, "Sweatshirt" },
                    { 3, "T-Shirts" }
                });

            migrationBuilder.InsertData(
                table: "ClothesSizesQuantities",
                columns: new[] { "Id", "LQuantity", "MQuantity", "SQuantity", "XlQuantity" },
                values: new object[,]
                {
                    { 1, 2, 5, 3, 1 },
                    { 2, 2, 5, 3, 1 },
                    { 3, 1, 2, 4, 0 }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, "dea12856-c198-4129-b3f3-b893d8395082", "Tosho", "Kukata", "+1 202-918-2132" });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "BrandId", "CategoryId", "ClothSizesQuantitiesId", "Description", "GenderOrientation", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, 1, 1, 1, "The moment you see the oversized baffles you know you’re looking at our iconic Nuptse. This warm, durable jacket has lofty 700-fill down, a water-repellent finish and a stowable hood. It also features 100% recycled fabrics and a design inspired by the classic 1996 version.", 0, "https://images.thenorthface.com/is/image/TheNorthFace/NF0A3C8D_LE4_int?wid=1300&hei=1510&fmt=jpeg&qlt=90&resMode=sharp2&op_usm=0.9,1.0,8,0", "Men’s 1996 Retro Nuptse Jacket", 750m });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "BrandId", "CategoryId", "ClothSizesQuantitiesId", "Description", "GenderOrientation", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, 2, 1, 2, "This Nike x Supreme Puffy Jacket worn by J Balvin features a reversible black polyester knit shell, with one side featuring an allover Nike Sportswear logo jacquard; and the other side a solid black knit with a Nike Sportswear logo on the left chest; grey snakeskin Nike logo above the back right hem; elastic cuffs; drawcord hem; zip front; & stand collar", 2, "https://incorporatedstyle.com/content/uploads/supreme-x-nike-ss21-black-puffy-jacket-550x459.jpg", "Nike x Supreme Black Reversible Puffer Jacket", 900m });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "BrandId", "CategoryId", "ClothSizesQuantitiesId", "Description", "GenderOrientation", "ImageUrl", "Name", "Price" },
                values: new object[] { 3, 3, 3, 3, "No need to overcomplicate things — this adidas t-shirt is all about ease. Keep your vibe real, real chill with the understated look. Though it doesn't give into full minimalism. The comfort goes all out, thanks to the super soft cotton build.", 0, "https://incorporatedstyle.com/content/uploads/supreme-x-nike-ss21-black-puffy-jacket-550x459.jpg", "Classics 3-Sstripes T-Shirt", 50m });

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_ClothesSizesQuantities_ClothSizesQuantitiesId",
                table: "Clothes",
                column: "ClothSizesQuantitiesId",
                principalTable: "ClothesSizesQuantities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_ClothesSizesQuantities_ClothSizesQuantitiesId",
                table: "Clothes");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClothesSizesQuantities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClothesSizesQuantities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClothesSizesQuantities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "ClothSizesQuantitiesId",
                table: "Clothes",
                newName: "SizesQuantities");

            migrationBuilder.RenameIndex(
                name: "IX_Clothes_ClothSizesQuantitiesId",
                table: "Clothes",
                newName: "IX_Clothes_SizesQuantities");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clothes",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(55)",
                oldMaxLength: 55);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac09644c-ad85-4f3c-9496-3233b4afbaf9", "AQAAAAEAACcQAAAAEJcEt1WehyzYBfVNAzL+BA84Bxb19p/kQtRD0LR2JIlNqXb3G8jbHK5chgU/JC93iA==", "a2e196eb-87de-4ca3-a542-56eb17e441c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53a94ed3-f3fd-44b8-9da6-12dc77e265d2", "AQAAAAEAACcQAAAAEMXyprs1UK/mOgI5aLufg0gf5+bZlxtYoFzoagis9apiEfC92vl0dr5hqwVuBBGnpg==", "ab2da260-66bd-4aea-9580-cf75f1723d51" });

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_ClothesSizesQuantities_SizesQuantities",
                table: "Clothes",
                column: "SizesQuantities",
                principalTable: "ClothesSizesQuantities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
