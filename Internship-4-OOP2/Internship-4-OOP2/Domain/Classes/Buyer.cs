using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Domain.Classes
{
    public class Buyer : User
    {
        public double Amount{ get; }
        public Buyer(string name, string email, double amount) : base(name, email)
        {
            Amount = amount;
        }
    }
}
