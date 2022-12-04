using ClothingShop.Core.Models.ClothModels;
using ClothingShop.Infrastructure.Data.Entities;

namespace ClothingShop.Core.Contracts
{
    public interface IClothService
    {
        Task<ClothesQueryModel> All(
            ClothesSorting sorting = ClothesSorting.Newest,
            string? category = null,
            string? searchTerm = null,
            int currentPage = 1,
            int clothesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<IEnumerable<int>> AllAvailableClothes();

        Task<IEnumerable<ClothesCategoryModel>> AllCategories();
        Task<IEnumerable<ClothesBrandModel>> AllBrands();

        Task<bool> CategoryExists(int categoryId);

        Task<bool> BrandExists(int brandId);

        Task Create(ClothAddToShopModel model);    
    }
}
    