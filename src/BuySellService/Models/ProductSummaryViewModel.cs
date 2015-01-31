using System;
using System.Collections.Generic;

namespace EShopper.Models
{
    public class ProductSummaryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfUnits { get; set; }
        public List<string> ImagePaths { get; set; }
        public string PostedById { get; set; }
        public string PostedUserName { get; set; }
        public float UnitPrice { get; set; }
        public double Rating { get; set; }
        public float Discount { get; set; }
        public DateTime DiscountValidity { get; set; }
        public Dictionary<string,string> Properties { get; set; }
        public string Location { get; set; }
    }

    public class ProductUploadModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfUnits { get; set; }
        public string ImagePaths { get; set; }
        public float UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public float Discount { get; set; }
    }

    public class ProductDetailsViewModel : ProductSummaryViewModel
    {
        public List<ProductCommentViewModel> ProductComments { get; set; }
    }


    public class ProductCommentViewModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int StarRating { get; set; }
        public int HelpfulHits { get; set; }
    }

}