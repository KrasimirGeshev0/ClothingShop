using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
