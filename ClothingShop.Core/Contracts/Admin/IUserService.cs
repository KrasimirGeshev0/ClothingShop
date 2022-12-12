using ClothingShop.Core.Models.AdminModels;

namespace ClothingShop.Core.Contracts.Admin
{
    public interface IUserService
    {
        Task<IEnumerable<UserServiceModel>> All();
    }
}
