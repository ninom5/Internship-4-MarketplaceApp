using MarketplaceApp.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Data.Models
{
    public class PromoCodes
    {
        public double Discount { get; set; }
        public DateTime ValidUntil { get; set; }
        public Category Category { get; set; }

        public List<PromoCodes> PromoCodesList { get; set; }
        public PromoCodes(double discount, DateTime validUntil, Category category) 
        {
            Discount = discount;
            ValidUntil = validUntil;
            Category = category;
        }
    }
}
