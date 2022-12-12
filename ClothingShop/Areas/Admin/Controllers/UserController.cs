using ClothingShop.Core.Contracts.Admin;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        public async Task<IActionResult> All()
        {
            var model = await userService.All();

            return View(model);
        }
    }
}
