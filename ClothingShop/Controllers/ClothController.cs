using ClothingShop.Core.Contracts;
using ClothingShop.Core.Models.ClothModels;
using ClothingShop.Models.Clothes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Controllers
{
    [Authorize]
    public class ClothController : Controller
    {
        private readonly IClothService clothService;


        public ClothController(IClothService _clothService)
        {
            clothService = _clothService;
        }

        public async Task<IActionResult> All([FromQuery] AllClothesQueryModel query)
        {
            var result = await clothService.All(
                query.Sorting,
                query.Category,
                query.SearchTerm,
                query.CurrentPage,
                AllClothesQueryModel.ClothesPerPage);

            query.TotalClothesCount = result.TotalClothesCount;
            query.Categories = await clothService.AllCategoriesNames();
            query.Clothes = result.Clothes;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ClothAddToShopModel()
            {
                Categories = await clothService.AllCategories(),
                Brands = await clothService.AllBrands()
            };

            return View(model);
        }

        public async Task<IActionResult> Add(ClothAddToShopModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await clothService.AllCategories();
                model.Brands = await clothService.AllBrands();
                return View(model);
            }

            if (await clothService.CategoryExists(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            if (await clothService.BrandExists(model.BrandId) == false)
            {
                ModelState.AddModelError(nameof(model.BrandId), "Brand does not exists");
            }

            await clothService.Create(model);

            return RedirectToAction(nameof(All), new AllClothesQueryModel()
            {
                Sorting = ClothesSorting.Newest
            });
        }

        //TODO Implement
        public async Task<IActionResult> Details()
        {
            return null;
        }

        //TODO Implement
        public async Task<IActionResult> Edit()
        {
            return null;
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await clothService.ClothExists(id))
            {
                await clothService.Delete(id);
            }
            else
            {
                throw new ArgumentException("Invalid ClothId");
            }

            return RedirectToAction(nameof(All));
        }

        //TODO Implement
        public async Task<IActionResult> AddToCart()
        {
            return null;
        }

    }
}
