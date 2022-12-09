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

        public async Task Create(CreateSellerModel model)
        {
            var seller = new Seller()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
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
    }
}
