﻿// <auto-generated />
using System;
using ClothingShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClothingShop.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221130234500_DbTestSeed")]
    partial class DbTestSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClothingShop.Infrastructure.Data.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "88c09e99-51f5-4e68-886d-73cddf11804f",
                            Email = "seller@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "SELLER@MAIL.COM",
                            NormalizedUserName = "SELLERUSER",
                            PasswordHash = "AQAAAAEAACcQAAAAECN2JlsXlrqcs3z9l2S62oVr/p8fvtqTFsM4pe9Vb9iqy8yhLGGAde5pPbDHZ6EYug==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5037ca0a-1eb1-4e16-9d93-440fa523d87d",
                            TwoFactorEnabled = false,
                            UserName = "SellerUser"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8bf4ad23-c7a8-4706-9723-ef764f51831a",
                            Email = "user@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@MAIL.COM",
                            NormalizedUserName = "NORMALUSER",
                            PasswordHash = "AQAAAAEAACcQAAAAEEv5OD9wF+jgjCHVRkKl+i43zFeKm/kttaiNoC7YXKJt7PqE87FbA4iVLYsbDUn0ag==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5f096fbe-475d-4eb0-ae28-9e9b1fa445d6",
                            TwoFactorEnabled = false,
                            UserName = "NormalUser"
                        });
                });

            modelBuilder.Entity("ClothingShop.Infrastructure.Data.Entities.ApplicationUserCloth", b =>
                {
                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ClothId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationUserId", "ClothId");

                    b.HasIndex("ClothId");

                    b.ToTable("ApplicationUsersClothes");
                });

            modelBuilder.Entity("ClothingShop.Infrastructure.Data.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Logo = "https://1000logos.net/wp-content/uploads/2017/05/Symbol-North-Face.jpg",
                            Name = "The North Face"
                        },
                        new
                        {
                            Id = 2,
                            Logo = "https://upload.wikimedia.org/wikipedia/commons/3/36/Logo_nike_principal.jpg",
                            Name = "Nike"
                        },
                        new
                        {
                            Id = 3,
                            Logo = "https://1000logos.net/wp-content/uploads/2019/06/Adidas-Logo-1991.jpg",
                            Name = "Addidas"
                        });
                });

            modelBuilder.Entity("ClothingShop.Infrastructure.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jackets"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sweatshirt"
                        },
                        new
                        {
                            Id = 3,
                            Name = "T-Shirts"
                        });
                });

            modelBuilder.Entity("ClothingShop.Infrastructure.Data.Entities.Cloth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ClothSizesQuantitiesId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderOrientation")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClothSizesQuantitiesId");

                    b.ToTable("Clothes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CategoryId = 1,
                            ClothSizesQuantitiesId = 1,
                            Description = "The moment you see the oversized baffles you know you’re looking at our iconic Nuptse. This warm, durable jacket has lofty 700-fill down, a water-repellent finish and a stowable hood. It also features 100% recycled fabrics and a design inspired by the classic 1996 version.",
                            GenderOrientation = 0,
                            ImageUrl = "https://images.thenorthface.com/is/image/TheNorthFace/NF0A3C8D_LE4_int?wid=1300&hei=1510&fmt=jpeg&qlt=90&resMode=sharp2&op_usm=0.9,1.0,8,0",
                            Name = "Men’s 1996 Retro Nuptse Jacket",
                            Price = 750m
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            CategoryId = 1,
                            ClothSizesQuantitiesId = 2,
                            Description = "This Nike x Supreme Puffy Jacket worn by J Balvin features a reversible black polyester knit shell, with one side featuring an allover Nike Sportswear logo jacquard; and the other side a solid black knit with a Nike Sportswear logo on the left chest; grey snakeskin Nike logo above the back right hem; elastic cuffs; drawcord hem; zip front; & stand collar",
                            GenderOrientation = 2,
                            ImageUrl = "https://incorporatedstyle.com/content/uploads/supreme-x-nike-ss21-black-puffy-jacket-550x459.jpg",
                            Name = "Nike x Supreme Black Reversible Puffer Jacket",
                            Price = 900m
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            CategoryId = 3,
                            ClothSizesQuantitiesId = 3,
                            Description = "No need to overcomplicate things — this adidas t-shirt is all about ease. Keep your vibe real, real chill with the understated look. Though it doesn't give into full minimalism. The comfort goes all out, thanks to the super soft cotton build.",
                            GenderOrientation = 0,
                            ImageUrl = "https://incorporatedstyle.com/content/uploads/supreme-x-nike-ss21-black-puffy-jacket-550x459.jpg",
                            Name = "Classics 3-Sstripes T-Shirt",
                            Price = 50m
                        });
                });

            modelBuilder.Entity("ClothingShop.Infrastructure.Data.Entities.ClothSizesQuantities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LQuantity")
                        .HasColumnType("int");

                    b.Property<int>("MQuantity")
                        .HasColumnType("int");

                    b.Property<int>("SQuantity")
                        .HasColumnType("int");

                    b.Property<int>("XlQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ClothesSizesQuantities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LQuantity = 2,
                            MQuantity = 5,
                            SQuantity = 3,
                            XlQuantity = 1
                        },
                        new
                        {
                            Id = 2,
                            LQuantity = 2,
                            MQuantity = 5,
                            SQuantity = 3,
                            XlQuantity = 1
                        },
                        new
                        {
                            Id = 3,
                            LQuantity = 1,
                            MQuantity = 2,
                            SQuantity = 4,
                            XlQuantity = 0
                        });
                });

            modelBuilder.Entity("ClothingShop.Infrastructure.Data.Entities.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Sellers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationUserId = "dea12856-c198-4129-b3f3-b893d8395082",
                            FirstName = "Tosho",
                            LastName = "Kukata",
                            PhoneNumber = "+1 202-918-2132"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ClothingShop.Infrastructure.Data.Entities.ApplicationUserCloth", b =>
                {
                    b.HasOne("ClothingShop.Infrastructure.Data.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserClothes")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingShop.Infrastructure.Data.Entities.Cloth", "Cloth")
                        .WithMany("ProductApplicationUsers")
                        .HasForeignKey("ClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Cloth");
                });

            modelBuilder.Entity("ClothingShop.Infrastructure.Data.Entities.Cloth", b =>
                {
                    b.HasOne("ClothingShop.Infrastructure.Data.Entities.Brand", "Brand")
                        .WithMany("Clothes")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingShop.Infrastructure.Data.Entities.Category", "Category")
                        .WithMany("Clothes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingShop.Infrastructure.Data.Entities.ClothSizesQuantities", "ClothSizesQuantities")
                        .WithMany()
                        .HasForeignKey("ClothSizesQuantitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("ClothSizesQuantities");
                });

            modelBuilder.Entity("ClothingShop.Infrastructure.Data.Entities.Seller", b =>
                {
                    b.HasOne("ClothingShop.Infrastructure.Data.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ClothingShop.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ClothingShop.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothingShop.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ClothingShop.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClothingShop.Infrastructure.Data.Entities.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUserClothes");
                });

            modelBuilder.Entity("ClothingShop.Infrastructure.Data.Entities.Brand", b =>
                {
                    b.Navigation("Clothes");
                });

            modelBuilder.Entity("ClothingShop.Infrastructure.Data.Entities.Category", b =>
                {
                    b.Navigation("Clothes");
                });

            modelBuilder.Entity("ClothingShop.Infrastructure.Data.Entities.Cloth", b =>
                {
                    b.Navigation("ProductApplicationUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
