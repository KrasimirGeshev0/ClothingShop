using ClothingShop.Core.Contracts;
using ClothingShop.Core.Models.SellerModels;
using ClothingShop.Infrastructure.Data.Common;
using ClothingShop.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Core.Services
{
    public class SellerService : ISellerService
    {
        private readonly IRepository repo;

        public SellerService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task Create(CreateSellerModel model, string userId)
        {
            var seller = new Seller()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                ApplicationUserId = userId
            };

            await repo.AddAsync(seller);
            await repo.SaveChangesAsync();
        }


        public async Task<bool> ExistsById(string sellerId)
        {
            return await repo.AllReadonly<Seller>().AnyAsync(s => s.ApplicationUserId == sellerId);
        }

        public async Task<bool> UserWithPhoneNumExistsById(string phoneNumber)
        {
            return await repo.AllReadonly<Seller>().AnyAsync(s => s.PhoneNumber == phoneNumber);
        }

        public async Task<int> GetSellerId(string userId)
        {
            return (await repo.AllReadonly<Seller>()
                .FirstOrDefaultAsync(a => a.ApplicationUserId == userId))?.Id ?? 0;
        }

        public async Task<string> GetSellerNameById(int sellerId)
        {
            var firstName = (await repo.GetByIdAsync<Seller>(sellerId)).FirstName;
            var lastName = (await repo.GetByIdAsync<Seller>(sellerId)).LastName;

            return firstName +" "+ lastName;
        }
    }
}
