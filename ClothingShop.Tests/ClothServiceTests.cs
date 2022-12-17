using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingShop.Core.Contracts;
using ClothingShop.Core.Models.ClothModels;
using ClothingShop.Core.Services;
using ClothingShop.Infrastructure.Data;
using ClothingShop.Infrastructure.Data.Common;
using ClothingShop.Infrastructure.Data.Entities;
using ClothingShop.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClothingShop.UTests
{
    [TestFixture]
    public class ClothServiceTests
    {
        private IRepository repo;
        private ISellerService sellerService;
        private IClothService clothService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("HouseDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task TestClothAll()
        {
            var repo = new Repository(applicationDbContext);
            var sellerService = new SellerService(repo);
            var clothService = new ClothService(repo, sellerService);

            await repo.AddAsync(new Cloth()
            {
                Id = 5,
                Name = "Jacket",
                Price = 25,
                Description = "Women Jacket",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Female,
                CategoryId = 1,
                Quantity = 2,
                BrandId = 1,
                SellerId = 1
            });

            await repo.AddAsync(new Cloth()
            {
                Id = 6,
                Name = "Jacket",
                Price = 23,
                Description = "Men jacket",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Male,
                CategoryId = 1,
                Quantity = 2,
                BrandId = 2,
                SellerId = 1
            });

            await repo.AddAsync(new Cloth()
            {
                Id = 7,
                Name = "Jacket",
                Price = 252,
                Description = "Women Jacket fdsgds",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Female,
                Quantity = 2,
                CategoryId = 1,
                BrandId = 1,
                SellerId = 1
            });
            await repo.SaveChangesAsync();

            var clothes = await clothService.All(sorting: ClothesSorting.Newest ,category: "Jackets", genderOrientation: "Female", currentPage: 1, clothesPerPage: 3);

            var dbClothes = await repo.AllReadonly<Cloth>().Where(c =>
                c.Category.Name == "Jackets" && c.GenderOrientation == ProductGenderOrient.Female  && c.IsAvailable).ToListAsync();


            Assert.That(clothes.TotalClothesCount == dbClothes.Count);


        }

        [Test]
        public async Task TestClothAllWithEnoughQuantity()
        {
            var repo = new Repository(applicationDbContext);
            var clothService = new ClothService(repo, sellerService);

            await repo.AddAsync(new Cloth()
            {
                Id = 5,
                Name = "Jacket",
                Price = 25,
                Description = "Women Jacket",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Female,
                CategoryId = 1,
                Quantity = 2,
                BrandId = 1,
                SellerId = 1
            });

            await repo.AddAsync(new Cloth()
            {
                Id = 6,
                Name = "Jacket",
                Price = 23,
                Description = "Men jacket",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Male,
                CategoryId = 1,
                Quantity = 2,
                BrandId = 2,
                SellerId = 1
            });

            await repo.AddAsync(new Cloth()
            {
                Id = 7,
                Name = "Jacket",
                Price = 252,
                Description = "Women Jacket fdsgds",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Female,
                Quantity = 0,
                CategoryId = 1,
                BrandId = 1,
                SellerId = 1
            });
            await repo.SaveChangesAsync();

            var clothes = await clothService.AllClothesWithEnoughQuantity();

            var dbClothes = await repo.AllReadonly<Cloth>().Where(c => c.Quantity > 0).ToListAsync();


            Assert.That(clothes.Count() == dbClothes.Count);


        }

        [Test]
        public async Task TestClothAllWithAvailableBrand()
        {
            var repo = new Repository(applicationDbContext);
            var clothService = new ClothService(repo, sellerService);

            await repo.AddAsync(new Brand()
            {
                Id = 5,
                Name = "Unavailable Brand",
                Logo = "",
                IsAvailable = false
            });

            await repo.AddAsync(new Brand()
            {
                Id = 6,
                Name = "Available Brand",
                Logo = "",
                IsAvailable = true
            });

            await repo.AddAsync(new Cloth()
            {
                Id = 5,
                Name = "Jacket",
                Price = 25,
                Description = "Women Jacket",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Female,
                CategoryId = 1,
                Quantity = 2,
                BrandId = 5,
                SellerId = 1
            });

            await repo.AddAsync(new Cloth()
            {
                Id = 6,
                Name = "Jacket",
                Price = 23,
                Description = "Men jacket",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Male,
                CategoryId = 1,
                Quantity = 2,
                BrandId = 5,
                SellerId = 1
            });

            await repo.AddAsync(new Cloth()
            {
                Id = 7,
                Name = "Jacket",
                Price = 252,
                Description = "Women Jacket fdsgds",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Female,
                Quantity = 0,
                CategoryId = 1,
                BrandId = 6,
                SellerId = 1
            });
            await repo.SaveChangesAsync();

            var clothes = await clothService.AllClothesWithAvailableBrand();

            var dbClothes = await repo.AllReadonly<Cloth>().Where(c => c.Brand.IsAvailable).ToListAsync();


            Assert.That(clothes.Count() == dbClothes.Count);


        }

        [Test]
        public async Task TestClothCategoryExists()
        {
            var repo = new Repository(applicationDbContext);
            var clothService = new ClothService(repo, sellerService);

            await repo.AddAsync(new Category()
            {
                Id = 5,
                Name = "",
            });

            await repo.SaveChangesAsync();

            var mustBeTrue = await clothService.CategoryExists(5);
            var mustBeFalse = await clothService.CategoryExists(6);


            Assert.That(mustBeTrue == true);
            Assert.That(mustBeFalse == false);


        }

        [Test]
        public async Task TestClothAllCategories()
        {
            var repo = new Repository(applicationDbContext);
            var clothService = new ClothService(repo, sellerService);

            await repo.AddAsync(new Category()
            {
                Id = 5,
                Name = "",
            });

            await repo.AddAsync(new Category()
            {
                Id = 6,
                Name = "",
            });

            await repo.AddAsync(new Category()
            {
                Id = 7,
                Name = "",
            });

            await repo.AddAsync(new Category()
            {
                Id = 8,
                Name = "",
            });

            await repo.SaveChangesAsync();

            var categories = await clothService.AllCategories();

            var dbCategories = await repo.AllReadonly<Category>().ToListAsync();


            Assert.That(categories.Count() == dbCategories.Count);

        }

        [Test]
        public async Task TestClothIsClothAvailableMethod()
        {
            var repo = new Repository(applicationDbContext);
            var clothService = new ClothService(repo, sellerService);

            await repo.AddAsync(new Cloth()
            {
                Id = 5,
                Name = "Jacket",
                Price = 25,
                Description = "Women Jacket",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Female,
                IsAvailable = false,
                CategoryId = 1,
                Quantity = 2,
                BrandId = 5,
                SellerId = 1
            });

            await repo.AddAsync(new Cloth()
            {
                Id = 6,
                Name = "Jacket",
                Price = 23,
                Description = "Men jacket",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Male,
                IsAvailable = true,
                CategoryId = 1,
                Quantity = 2,
                BrandId = 5,
                SellerId = 1
            });

            await repo.SaveChangesAsync();

            var mustBeTrue = await clothService.IsClothAvailable(6);
            var mustBeFalse = await clothService.IsClothAvailable(5);
            var invalidId = await clothService.IsClothAvailable(13);

            Assert.That(mustBeTrue = true);
            Assert.That(mustBeFalse == false);
            Assert.That(invalidId == false);


        }


        [Test]
        public async Task TestClothCreate()
        {
            var repo = new Repository(applicationDbContext);
            var clothService = new ClothService(repo, sellerService);

            var repoCount = repo.AllReadonly<Cloth>().Count();

            int sellerId = 1;
            var cloth = new ClothAddToShopAndEditModel()
            {
                Name = "",
                Price = 23,
                Description = "Edited",
                GenderOrientation = "Male",
                ImageUrl = "",
            };
            await clothService.Create(cloth, sellerId);

            var repoCountAfterCreate = repo.AllReadonly<Cloth>().Count();

            Assert.That(repoCount + 1 == repoCountAfterCreate);
        }

        [Test]
        public async Task TestClothEdit()
        {
            var repo = new Repository(applicationDbContext);
            var clothService = new ClothService(repo, sellerService);

            await repo.AddAsync(new Cloth()
            {
                Id = 5,
                Name = "",
                Price = 23,
                Description = "",
                ImageUrl = "",
            });

            await repo.SaveChangesAsync();

            await clothService.Edit(new ClothAddToShopAndEditModel()
            {
                Id = 5,
                Name = "",
                Price = 23,
                Description = "Edited",
                GenderOrientation = "Male",
                ImageUrl = "",
            });

            var dbCloth = await repo.GetByIdAsync<Cloth>(5);

            Assert.That(dbCloth.Description, Is.EqualTo("Edited"));
        }


        [Test]
        public async Task TestClothDelete()
        {
            var repo = new Repository(applicationDbContext);
            var clothService = new ClothService(repo, sellerService);

            await repo.AddAsync(new Cloth()
            {
                Id = 5,
                Name = "",
                Price = 23,
                Description = "",
                ImageUrl = "",
            });

            await repo.SaveChangesAsync();

            await clothService.Delete(5);

            var dbCloth = await repo.GetByIdAsync<Cloth>(5);

            Assert.That(dbCloth.IsAvailable == false);
        }

        [Test]
        public async Task TestGetClothCategoryId()
        {
            var repo = new Repository(applicationDbContext);
            var clothService = new ClothService(repo, sellerService);

            await repo.AddAsync(new Category()
            {
                Id = 5,
                Name = "Catgory 5",
            });

            await repo.AddAsync(new Cloth()
            {
                Id = 6,
                Name = "Jacket",
                Price = 23,
                Description = "Men jacket",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Male,
                IsAvailable = true,
                CategoryId = 5,
                Quantity = 2,
                BrandId = 5,
                SellerId = 1
            });
            await repo.SaveChangesAsync();

            var categoryId = await clothService.GetClothCategoryId(6);


            var dbCloth = await repo.GetByIdAsync<Cloth>(6);
         
            Assert.That(dbCloth.Category.Id == categoryId);
        }

        [Test]
        public async Task TestGetClothBrandId()
        {
            var repo = new Repository(applicationDbContext);
            var clothService = new ClothService(repo, sellerService);

            await repo.AddAsync(new Brand()
            {
                Id = 5,
                Name = "Brand",
                Logo = "",
                IsAvailable = true
            });

            await repo.AddAsync(new Cloth()
            {
                Id = 6,
                Name = "Jacket",
                Price = 23,
                Description = "Men jacket",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Male,
                IsAvailable = true,
                CategoryId = 5,
                Quantity = 2,
                BrandId = 5,
                SellerId = 1
            });
            await repo.SaveChangesAsync();

            var brandId = await clothService.GetClothBrandId(6);


            var dbCloth = await repo.GetByIdAsync<Cloth>(6);

            Assert.That(dbCloth.Brand.Id == brandId);
        }

        [Test]
        public async Task TestGetClothDetails()
        {
            var repo = new Repository(applicationDbContext);
            var clothService = new ClothService(repo, sellerService);


            await repo.AddAsync(new Brand()
            {
                Id = 5,
                Name = "Brand",
                Logo = "",
                IsAvailable = true
            });

            await repo.AddAsync(new Cloth()
            {
                Id = 6,
                Name = "Jacket",
                Price = 23,
                Description = "The best jacket ever",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Male,
                IsAvailable = true,
                CategoryId = 5,
                Quantity = 2,
                BrandId = 5,
                SellerId = 1
            });
            await repo.SaveChangesAsync();

            var details = await clothService.GetClothDetails(6);

            var dbCloth = await repo.GetByIdAsync<Cloth>(6);

            Assert.That(dbCloth.Price == details.Price);
            Assert.That(dbCloth.Description == details.Description);
        }

        [Test]
        public async Task TestAllClothesByBrandId()
        {
            var repo = new Repository(applicationDbContext);
            var clothService = new ClothService(repo, sellerService);

            await repo.AddAsync(new Cloth()
            {
                Id = 6,
                Name = "Jacket",
                Price = 23,
                Description = "The best jacket ever",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Male,
                Quantity = 2,
                BrandId = 5,
            });

            await repo.AddAsync(new Cloth()
            {
                Id = 8,
                Name = "Jasdfet",
                Price = 23,
                Description = "Msdfasd jacket",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Male,
                CategoryId = 1,
                Quantity = 2,
                BrandId = 7,
                SellerId = 1
            });

            await repo.AddAsync(new Cloth()
            {
                Id = 7,
                Name = "Jacket",
                Price = 252,
                Description = "Women Jacket fdsgds",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Female,
                Quantity = 2,
                BrandId = 5,
            });

            await repo.SaveChangesAsync();

            var allClotheByBrand = await clothService.AllClothesByBrandId(5);

            var dbCloth = await repo.AllReadonly<Cloth>().Where(c => c.Brand.Id == 5).ToListAsync();

            Assert.That(dbCloth.Count == allClotheByBrand.Count());
        }

        //[Test]
        //public async Task TestAllClothesBySellerId()
        //{
        //    var repo = new Repository(applicationDbContext);
        //    var clothService = new ClothService(repo, sellerService);

        //    await repo.AddAsync(new ApplicationUser()
        //    {
        //        Id = "as",
        //        UserName = "asd",
        //        NormalizedUserName = "ASD",
        //        Email = "asd",
        //        NormalizedEmail = "ASD"
        //    });

        //    await repo.AddAsync(new Seller()
        //    {
        //        Id = 1,
        //        PhoneNumber = "",
        //        FirstName = "asd",
        //        LastName = "asd",
        //        ApplicationUserId = "as"
        //    });

        //    await repo.AddAsync(new Cloth()
        //    {
        //        Id = 6,
        //        Name = "Jacket",
        //        Price = 23,
        //        Description = "The best jacket ever",
        //        ImageUrl = "",
        //        GenderOrientation = ProductGenderOrient.Male,
        //        IsAvailable = true,
        //        BrandId = 1,
        //        CategoryId = 1,
        //        Quantity = 2,
        //        SellerId = 1
        //    });

        //    await repo.AddAsync(new Cloth()
        //    {
        //        Id = 8,
        //        Name = "Jasdfet",
        //        Price = 23,
        //        Description = "Msdfasd jacket",
        //        ImageUrl = "",
        //        GenderOrientation = ProductGenderOrient.Male,
        //        IsAvailable = true,
        //        BrandId = 1,
        //        CategoryId = 1,
        //        Quantity = 2,
        //        SellerId = 1
        //    });

        //    await repo.AddAsync(new Cloth()
        //    {
        //        Id = 7,
        //        Name = "Jacket",
        //        Price = 252,
        //        Description = "Women Jacket fdsgds",
        //        ImageUrl = "",
        //        GenderOrientation = ProductGenderOrient.Female,
        //        IsAvailable = true,
        //        BrandId = 1,
        //        CategoryId = 1,
        //        Quantity = 2,
        //        SellerId = 1
        //    });

        //    await repo.SaveChangesAsync();

        //    var allClotheBySellerId = await clothService.AllClothesBySellerId(1);

        //    var dbCloth = await repo.AllReadonly<Cloth>().Where(c => c.SellerId == 1).ToListAsync();

        //    Assert.That(dbCloth.Count == allClotheBySellerId.Count());
        //}

        [Test]
        public async Task TestAddClothToUsersCart()
        {
            var repo = new Repository(applicationDbContext);
            var clothService = new ClothService(repo, sellerService);

            await repo.AddAsync(new ApplicationUser()
            {
                Id = "as",
                UserName = "asd",
                NormalizedUserName = "ASD",
                Email = "asd",
                NormalizedEmail = "ASD"
            });

            await repo.AddAsync(new Cloth()
            {
                Id = 6,
                Name = "Jacket",
                Price = 23,
                Description = "The best jacket ever",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Male,
                IsAvailable = true,
                CategoryId = 5,
                Quantity = 2,
                BrandId = 5,
                SellerId = 1
            });

            await repo.SaveChangesAsync();

            await clothService.AddClothToUsersCart(6, "as");

            var dbCloth = await repo.AllReadonly<ApplicationUserCloth>().Where(ac => ac.ApplicationUserId == "as" && ac.ClothId == 6).FirstAsync();

            Assert.That(dbCloth.ApplicationUserId == "as");
            Assert.That(dbCloth.ClothId == 6);
        }

        //UserCartClothes
        [Test]
        public async Task TestUserCartClothes()
        {
            var repo = new Repository(applicationDbContext);
            var clothService = new ClothService(repo, sellerService);

            await repo.AddAsync(new ApplicationUser()
            {
                Id = "as",
                UserName = "asd",
                NormalizedUserName = "ASD",
                Email = "asd",
                NormalizedEmail = "ASD"
            });
            await repo.AddAsync(new ApplicationUser()
            {
                Id = "ass",
                UserName = "assd",
                NormalizedUserName = "ASSD",
                Email = "assd",
                NormalizedEmail = "ASSD"
            });

            await repo.AddAsync(new Cloth()
            {
                Id = 6,
                Name = "Jacket",
                Price = 23,
                Description = "The best jacket ever",
                ImageUrl = "",
                GenderOrientation = ProductGenderOrient.Male,
                IsAvailable = true,
                CategoryId = 5,
                Quantity = 2,
                BrandId = 5,
                SellerId = 1
            });

            await repo.SaveChangesAsync();

            var userClothes = await clothService.UserCartClothes("as");

            var dbCloth = await repo.AllReadonly<ApplicationUserCloth>().Where(ac => ac.ApplicationUserId == "as" && ac.Cloth.IsAvailable).ToListAsync();

            Assert.That(dbCloth.Count == userClothes.Count());
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
