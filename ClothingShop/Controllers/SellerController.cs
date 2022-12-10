using ClothingShop.Core.Contracts;
using ClothingShop.Core.Models.SellerModels;
using ClothingShop.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Controllers
{
    public class SellerController : Controller
    {
        private readonly ISellerService sellerService;

        public SellerController(ISellerService _sellerService)
        {
            sellerService = _sellerService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {

            if (await sellerService.ExistsById(User.Id()))
            {
                //TempData[MessageConstant.ErrorMessage] = "You are already seller!";

                return RedirectToAction("Index", "Home");
            }

            var model = new CreateSellerModel();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Become(CreateSellerModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await sellerService.ExistsById(userId))
            {
                //TempData[MessageConstant.ErrorMessage] = "You are already seller!";

                return RedirectToAction("Index", "Home");
            }

            if (await sellerService.UserWithPhoneNumExistsById(model.PhoneNumber))
            {
                //TempData[MessageConstant.ErrorMessage] = "Seller with this phone number already exists!";

                return RedirectToAction("Index", "Home");
            }

            await sellerService.Create(model, userId);

            return RedirectToAction("All", "Cloth");
        }
    }
}
