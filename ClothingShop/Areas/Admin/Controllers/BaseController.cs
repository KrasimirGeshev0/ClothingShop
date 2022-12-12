using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ClothingShop.Areas.Admin.Constants.AdminConstants;

namespace ClothingShop.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]
    public class BaseController : Controller
    {
    }
}
