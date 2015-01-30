﻿using System;
using System.Collections.Generic;
using CW.Backend.DAL.Base.Entities;

namespace CW.Backend.DAL.CRUD.Entities
{
    public class Product: BaseCoreEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfUnits { get; set; }
        public string ImagePath { get; set; }
        public ICollection<ProductTag> Tags { get; set; }
        public ICollection<ProductComment> Comments { get; set; }
        public ICollection<ProductProperty> Properties { get; set; }
        public ICollection<ProductGroup> Groups { get; set; }
        public ICollection<Order> Orders { get; set; }
 
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int PostedUserId { get; set; }
        public virtual ApplicationUser PostedBy { get; set; }

        public float UnitPrice { get; set; }
        public float Discount { get; set; }
        public DateTime DiscountValidity { get; set; }
  
//        public int ProductPriceId { get; set; }
//        public virtual ProductPrice Price { get; set; }
    }
}
