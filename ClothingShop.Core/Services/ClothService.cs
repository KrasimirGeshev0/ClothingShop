using ClothingShop.Core.Contracts;
using ClothingShop.Core.Models.ClothModels;
using ClothingShop.Infrastructure.Data.Common;
using ClothingShop.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Core.Services
{
    public class ClothService : IClothService
    {
        private readonly IRepository repo;

        public ClothService(IRepository _repository)
        {
            repo = _repository;
        }


        public async Task<ClothesQueryModel> All(ClothesSorting sorting = ClothesSorting.Newest, string? category = null, string? searchTerm = null,
            int currentPage = 1, int clothesPerPage = 1)
        {
            var result = new ClothesQueryModel();
            var availableClothes = await AllAvailableClothes();
            var clothes = repo.AllReadonly<Cloth>().Where(c => availableClothes.Contains(c.Id));

            if (string.IsNullOrEmpty(category) == false)
            {
                clothes = clothes
                    .Where(c => c.Category.Name == category);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                clothes = clothes
                    .Where(c => EF.Functions.Like(c.Name.ToLower(), searchTerm) ||
                                EF.Functions.Like(c.Description.ToLower(), searchTerm) ||
                                EF.Functions.Like(c.Brand.Name.ToLower(), searchTerm));
            }

            clothes = sorting switch
            {
                ClothesSorting.PriceAscending => clothes
                    .OrderBy(h => h.Price),
                ClothesSorting.PriceDescending => clothes
                    .OrderByDescending(h => h.Price),
                ClothesSorting.Newest => clothes.OrderByDescending(h => h.Id)
            };

            result.Clothes = await clothes
                .Skip((currentPage - 1) * clothesPerPage)
                .Take(clothesPerPage)
                .Select(c => new ClothesServiceModel()
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    Price = c.Price,
                    Name = c.Name,
                    Category = c.Category.Name
                })
                .ToListAsync();

            result.TotalClothesCount = await clothes.CountAsync();

            return result;
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<int>> AllAvailableClothes()
        {
            return await repo.AllReadonly<Cloth>()
                .Where(c => c.Quantity > 0)
                .Select(c => c.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<ClothesCategoryModel>> AllCategories()
        {
            return await repo.AllReadonly<Category>()
                .Select(c => new ClothesCategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<IEnumerable<ClothesBrandModel>> AllBrands()
        {
            return await repo.AllReadonly<Brand>()
                .Select(c => new ClothesBrandModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repo.AllReadonly<Category>().AnyAsync(c => c.Id == categoryId);
        }

        public async Task<bool> BrandExists(int brandId)
        {
            return await repo.AllReadonly<Brand>().AnyAsync(b => b.Id == brandId);
        }

        public async Task Create(ClothAddToShopModel model)
        {
            var cloth = new Cloth()
            {
                Name = model.Name,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Quantity = model.Quantity,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
            };

            await repo.AddAsync(cloth);
            await repo.SaveChangesAsync();
        }
    }
}
