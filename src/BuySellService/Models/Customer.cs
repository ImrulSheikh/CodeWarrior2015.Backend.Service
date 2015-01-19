﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientData.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Profile BuyerProfile { get; set; }
        public Profile SellerProfile { get; set; }
    }

    public class Profile
    {
        public int ItemSoldPurchased { get; set; }
        public string Address { get; set; }

    }
}