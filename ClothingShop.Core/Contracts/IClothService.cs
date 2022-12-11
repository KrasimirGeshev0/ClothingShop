using ClothingShop.Core.Models.ClothModels;
using ClothingShop.Infrastructure.Data.Entities;

namespace ClothingShop.Core.Contracts
{
    public interface IClothService
    {
        Task<ClothesQueryModel> All(
            ClothesSorting sorting = ClothesSorting.Newest,
            string? category = null,
            string? genderOrientation = null,
            string? searchTerm = null,
            int currentPage = 1,
            int clothesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<IEnumerable<int>> AllClothesWithEnoughQuantity();
        Task<IEnumerable<int>> AllClothesWithAvailableBrand();

        Task<IEnumerable<ClothesCategoryModel>> AllCategories();
        Task<IEnumerable<ClothesBrandModel>> AllBrands();

        Task<bool> CategoryExists(int categoryId);

        Task<bool> BrandExists(int brandId);

        Task<bool> IsClothAvailable(int clothId);

        Task Create(ClothAddToShopAndEditModel model, int sellerId); 

        Task Delete(int clothId);

        Task Edit(ClothAddToShopAndEditModel model);

        Task<int> GetClothCategoryId(int clothId);

        Task<int> GetClothBrandId(int clothId);

        Task<ClothDetailsModel> GetClothDetails(int clothId);

        Task<IEnumerable<ClothesServiceModel>> AllClothesByBrandId(int brandId);

        Task<IEnumerable<ClothesServiceModel>> AllClothesBySellerId(int sellerId);

        Task AddClothToUsersCart(int clothId, string userId);

        Task<IEnumerable<ClothesServiceModel>> UserCartClothes(string userId);

        Task RemoveClothFromUserCart(int clothId, string userId);

        Task<ClothDetailsModel> ClothDetails(int clothId);


    }
}