using ClothingShop.Core.Contracts;
using ClothingShop.Core.Models.BrandModels;
using ClothingShop.Core.Services;
using ClothingShop.Infrastructure.Data;
using ClothingShop.Infrastructure.Data.Common;
using ClothingShop.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ClothingShop.UTests;

[TestFixture]
public class BrandServiceTests
{
    private IRepository repo;
    private IBrandService brandService;
    private ApplicationDbContext applicationDbContext;

    [SetUp]
    public void Setup()
    {
        var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("BrandDB")
            .Options;

        applicationDbContext = new ApplicationDbContext(contextOptions);

        applicationDbContext.Database.EnsureDeleted();
        applicationDbContext.Database.EnsureCreated();
    }

    [Test]
    public async Task TestBrandCreate()
    {
        var repo = new Repository(applicationDbContext);
        var brandService = new BrandService(repo);

        var repoCount = repo.AllReadonly<Brand>().Count();

        var brand = new CreateBrandModel()
        {
            Name = "",
            Logo = "",
        };
        await brandService.Create(brand);

        var repoCountAfterCreate = repo.AllReadonly<Brand>().Count();

        Assert.That(repoCount + 1 == repoCountAfterCreate);
    }
    //Delete

    [Test]
    public async Task TestBrandDelete()
    {
        var repo = new Repository(applicationDbContext);
        var brandService = new BrandService(repo);

        await repo.AddAsync(new Brand()
        {
            Id = 1,
            Name = "",
            Logo = "",
            IsAvailable = true
        });

        await repo.SaveChangesAsync();
        
        await brandService.Delete(1);

        var repoBrand= await repo.GetByIdAsync<Brand>(1);

        Assert.That(repoBrand.IsAvailable == false);
    }

    [Test]
    public async Task TestGetBrandNameById()
    {
        var repo = new Repository(applicationDbContext);
        var brandService = new BrandService(repo);

        await repo.AddAsync(new Brand()
        {
            Id = 1,
            Name = "",
            Logo = "",
            IsAvailable = true
        });

        await repo.SaveChangesAsync();

        var name = await brandService.GetBrandNameById(1);

        var repoBrand = await repo.GetByIdAsync<Brand>(1);

        Assert.That(name == repoBrand.Name);
    }

    [TearDown]
    public void TearDown()
    {
        applicationDbContext.Dispose();
    }
}