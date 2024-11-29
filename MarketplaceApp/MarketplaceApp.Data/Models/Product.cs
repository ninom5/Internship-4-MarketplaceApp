
namespace MarketplaceApp.Data.Models
{
    public class Product
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public double Price { get; set; }
        public Seller Seller { get; protected set; }
        public Enum.ProductStatus ProductStatus { get; set; }
        public Enum.Category ProductType { get; protected set; }
        public double Rating { get; set; }
        public Product(string name, string description, double price, Enum.Category productType, Seller seller, double rating)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            ProductStatus = Enum.ProductStatus.Na_prodaji;
            ProductType = productType;
            Seller = seller;
            Rating = rating;
        }
    }
}
