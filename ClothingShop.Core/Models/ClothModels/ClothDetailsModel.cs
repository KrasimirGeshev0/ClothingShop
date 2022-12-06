namespace ClothingShop.Core.Models.ClothModels
{
    public class ClothDetailsModel
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Quantity { get; set; }

        public string GenderOrientation { get; set; } = null!;
    }
}
