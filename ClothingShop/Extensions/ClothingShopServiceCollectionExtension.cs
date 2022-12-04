﻿using ClothingShop.Core.Contracts;
using ClothingShop.Core.Services;
using ClothingShop.Infrastructure.Data.Common;

namespace ClothingShop.Extensions
{
    public static class ClothingShopServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IClothService, ClothService>();
            
            return services;
        }
    }
}