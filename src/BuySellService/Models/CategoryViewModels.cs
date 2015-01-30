using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CW.Backend.DAL.CRUD.Entities;

namespace EShopper.Models {
    public class CategoryViewModels {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<CategoryViewModels> SubCategories { get; set; }
    }

    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfUnits { get; set; }
        public List<string> ImagePaths { get; set; }

        public float UnitPrice { get; set; }
        public float Discount { get; set; }
        public DateTime DiscountValidity { get; set; }
    }

    public class ProductCommentViewModel {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int StarRating { get; set; }
        public int HelpfulHits { get; set; }
    }

    public class PropertyViewModel
    {
    }
}