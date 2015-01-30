using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CW.Backend.DAL.CRUD.Entities;

namespace EShopper.Models
{
    public class WishlistViewModel
    {
        public WishlistViewModel(UserWishlist data)
        {
            Id = data.Id;
            UserId = data.ApplicationUserId;
            UserName = data.ApplicationUser.UserName;

            var prodList = data.Products.ToList();

            Products = new List<ProductViewModel>();
            foreach (var product in prodList)
            {
                Products.Add(new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Discount = product.Discount,
                    NumberOfUnits = product.NumberOfUnits,
                    DiscountValidity = product.DiscountValidity,
                    UnitPrice = product.UnitPrice,
                    ImagePaths =
                        product.ImagePaths.Split(new[] {CW.Backend.DAL.Base.Constants.ObjectSeperator},
                            StringSplitOptions.RemoveEmptyEntries).ToList()
                });
            }
        }

        public int Id { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

    }
}