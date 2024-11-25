using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Domain.Classes
{
    public class Product
    {
        private Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public double Price { get; protected set; }
        public Seller Seller { get; protected set; }
        public Data.ProductStatus ProductStatus { get; set; }
        public Data.Category ProductType { get; protected set; }
        public Product(string name, string description, double price, Data.Category productType, Seller seller)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            ProductStatus = Data.ProductStatus.Na_prodaji;
            ProductType = productType;
            Seller = seller;
        }
        public Guid getId()
        {
            return Id;
        }
    }
}
