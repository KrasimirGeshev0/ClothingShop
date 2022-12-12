using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingShop.Core.Contracts;
using ClothingShop.Core.Contracts.Admin;
using ClothingShop.Core.Models.AdminModels;
using ClothingShop.Infrastructure.Data.Common;
using ClothingShop.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Core.Services.Admin
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISellerService sellerService;

        public UserService(
            IRepository _repo,
            UserManager<ApplicationUser> _userManager,
            ISellerService _sellerService)
        {
            repo = _repo;
            userManager = _userManager;
            sellerService = _sellerService;
        }

        public async Task<IEnumerable<UserServiceModel>> All()
        {
            List<UserServiceModel> result;

            result = await repo.AllReadonly<Seller>()
                .Where(s => s.ApplicationUser.IsActive)
                .Select(s => new UserServiceModel()
                {
                    UserId = s.ApplicationUserId,
                    Email = s.ApplicationUser.Email,
                    UserName = s.ApplicationUser.UserName,
                    PhoneNumber = s.PhoneNumber,
                    SellerId = s.Id
                })
                .ToListAsync();

            foreach (var seller in result)
            {
                seller.FullName = await sellerService.GetSellerNameById(seller.SellerId ?? 0);
            }

            string[] sellersIds = result.Select(a => a.UserId).ToArray();

            result.AddRange(await repo.AllReadonly<ApplicationUser>()
                .Where(u => sellersIds.Contains(u.Id) == false)
                .Where(u => u.IsActive)
                .Select(u => new UserServiceModel()
                {
                    UserId = u.Id,
                    Email = u.Email,
                    UserName = u.UserName
                }).ToListAsync());

            return result;
        }
    }
}
