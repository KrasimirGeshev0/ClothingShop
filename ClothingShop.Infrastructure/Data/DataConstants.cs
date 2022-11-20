namespace ClothingShop.Infrastructure.Data
{
    internal class DataConstants
    {
        public class User
        {
            public const int FirstNameMaxLength = 30;
            public const int FirstNameMinLength = 2;

            public const int LastNameMaxLength = 30;
            public const int LastNameMinLength = 2;

            public const int UserNameMaxLength = 20;
            public const int UserNameMinLength = 5;

            public const int EmailMaxLength = 60;
            public const int EmailMinLength = 10;

            public const int PasswordMaxLength = 20;
            public const int PasswordMinLength = 5;
        }

        public class Product
        {
            public const int NameMaxLength = 40;
            public const int NameMinLength = 5;

            public const int QuantityMax = 500;
            public const int QuantityMin = 1;

            public const int DescriptionMaxLength = 5000;
            public const int DescriptionMinLength = 5;
        }

        public class Category
        {
            public const int NameMaxLength = 25;
            public const int NameMinLength = 3;
        }

        public class Brand
        {
            public const int NameMaxLength = 30;
            public const int NameMinLength = 2;
        }

    }
}
