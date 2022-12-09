using ClothingShop.Core.Contracts;
using ClothingShop.Core.Models.BrandModels;
using ClothingShop.Models.Brands;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService _brandService)
        {
            brandService = _brandService;
        }

        public async Task<IActionResult> All([FromQuery] AllBrandsQueryModel query)
        {
            var result = await brandService.All(
                query.SearchTerm);

            query.Brands = result;

            return View(query);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new CreateBrandModel();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateBrandModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await brandService.Create(model);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await brandService.IsBrandAvailable(id))
            {
                await brandService.Delete(id);
            }
            else
            {
                throw new ArgumentException("Invalid BrandId");
            }

            return RedirectToAction(nameof(All));
        }

    }
}
