﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Domain.Classes
{
    public class Seller : User
    {
        public double Earnings { get; private set; }
        public Seller(string name, string email) : base(name, email)
        {
            Earnings = 0;
        }

        public void SetNewEarnings(double amount)
        {
            Earnings += amount;
        }
    }
}