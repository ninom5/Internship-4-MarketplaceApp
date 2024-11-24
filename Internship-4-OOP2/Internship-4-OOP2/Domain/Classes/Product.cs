using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Domain.Classes
{
    public class Product
    {
        public Dictionary<Guid, Tuple<string, string, double, Buyer, Enum, Enum>> productDictonary = new Dictionary<Guid, Tuple<string, string, double, Buyer, Enum, Enum>>();
        private Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public double Price { get; protected set; }
        public Buyer? Buyer;
        public Enum ProductStatus { get; protected set; }
        public Enum ProductType { get; protected set; }
        public Product(string name, string description, double price, Enum productType)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            ProductStatus = Data.ProductStatus.Na_prodaji;
            ProductType = productType;
        }
    }
}
