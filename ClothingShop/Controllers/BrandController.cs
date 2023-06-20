    using ClothingShop.Core.Contracts;
using ClothingShop.Core.Models.BrandModels;
using ClothingShop.Models.Brands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ClothingShop.Areas.Admin.Constants.AdminConstants;

namespace ClothingShop.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService _brandService)
        {
            brandService = _brandService;
        }

        [AllowAnonymous]
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
            if (this.User.IsInRole(AdminRoleName) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }
            var model = new CreateBrandModel();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateBrandModel model)
        {
            if (this.User.IsInRole(AdminRoleName) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await brandService.Create(model);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (this.User.IsInRole(AdminRoleName) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

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
