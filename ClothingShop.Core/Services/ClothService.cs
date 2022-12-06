using ClothingShop.Core.Contracts;
using ClothingShop.Core.Models.ClothModels;
using ClothingShop.Infrastructure.Data.Common;
using ClothingShop.Infrastructure.Data.Entities;
using ClothingShop.Infrastructure.Data.Enums;
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
            var availableClothes = await AllClothesWithEnoughQuantity();
            var clothes = repo.AllReadonly<Cloth>().Where(c => availableClothes.Contains(c.Id) && c.IsAvailable);

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

        public async Task<IEnumerable<int>> AllClothesWithEnoughQuantity()
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

        public async Task<bool> IsClothAvailable(int clothId)
        {
            if (await repo.AllReadonly<Cloth>().AnyAsync(c => c.Id == clothId))
            {
                if (await repo.AllReadonly<Cloth>().Where(c => c.Id == clothId).Select(c => c.IsAvailable).FirstOrDefaultAsync())
                {
                    return true;
                }
            }

            return false;

        }

        public async Task Create(ClothAddToShopAndEditModel model)  
        {
            var cloth = new Cloth()
            {
                Name = model.Name,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Quantity = model.Quantity,
                BrandId = model.BrandId,
                GenderOrientation = Enum.Parse<ProductGenderOrient>(model.GenderOrientation),
                CategoryId = model.CategoryId,
            };

            await repo.AddAsync(cloth);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(int clothId)
        {
            var cloth = await repo.All<Cloth>()
                .FirstOrDefaultAsync(c => c.Id == clothId);

            if (cloth != null)
            {
                cloth.IsAvailable = false;
            }

            await repo.SaveChangesAsync();
        }

        public async Task Edit(ClothAddToShopAndEditModel model)
        {
            var cloth = await repo.GetByIdAsync<Cloth>(model.Id);

            cloth.Name = model.Name;
            cloth.Price = model.Price;
            cloth.ImageUrl = model.ImageUrl;
            cloth.Description = model.Description;
            cloth.Quantity = model.Quantity;
            cloth.BrandId = model.BrandId;
            cloth.CategoryId = model.CategoryId;
            cloth.GenderOrientation = Enum.Parse<ProductGenderOrient>(model.GenderOrientation);

            await repo.SaveChangesAsync();
        }

        public async Task<int> GetClothCategoryId(int clothId)
        {
            return (await repo.GetByIdAsync<Cloth>(clothId)).CategoryId;
        }

        public async Task<int> GetClothBrandId(int clothId)
        {
            return (await repo.GetByIdAsync<Cloth>(clothId)).BrandId;
        }

        public async Task<ClothDetailsModel> GetClothDetails(int clothId)
        {
            return await repo.AllReadonly<Cloth>()
                .Where(c => c.Id == clothId)
                .Select(c => new ClothDetailsModel()
                {
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Price,
                    Quantity = c.Quantity,
                    ImageUrl = c.ImageUrl,
                    GenderOrientation = c.GenderOrientation.ToString(),
                }).FirstAsync();
        }
    }
}
