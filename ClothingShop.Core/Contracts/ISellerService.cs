﻿using ClothingShop.Core.Models.SellerModels;

namespace ClothingShop.Core.Contracts
{
    public interface ISellerService
    {
        Task Create(CreateSellerModel model, string userId);

        Task<bool> ExistsById(string userId);

        Task<bool> UserWithPhoneNumExistsById(string userId);
    }
}
