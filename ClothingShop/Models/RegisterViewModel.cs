﻿using System.ComponentModel.DataAnnotations;
using ClothingShop.Infrastructure.Data;
using static ClothingShop.Infrastructure.Data.DataConstants.User;

namespace ClothingShop.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(DataConstants.User.UserNameMaxLength, MinimumLength = DataConstants.User.UserNameMinLength)]
        public string UserName { get; set; } = null!;


        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}