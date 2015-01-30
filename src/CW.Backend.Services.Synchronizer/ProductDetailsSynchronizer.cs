using System;
using System.Collections.Generic;
using System.Linq;
using CW.Backend.DAL.Base;
using CW.Backend.DAL.CRUD.Contexts;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories;
using CW.Backend.DAL.Query;
using CW.Backend.DAL.Query.Entities;
using CW.Backend.DAL.Query.Repositories;

namespace CW.Backend.Services.Synchronizer
{
    public class ProductDetailsSynchronizer
    {
        private static DateTime LastSynced;
        public void Sync()
        {
            var syncingTime = DateTime.Now;
            var crudContext = new ProductCRUDContext();
            var queryContext = new ProductFlatContext();
            IEnumerable<ProductDetails> productDetailsEntries;

            using (var cRepo = new ProductRepository(crudContext))
            {
                var productsToBeUpdated =
                    cRepo.GetAll().Where(p => p.UpdatedOn >= LastSynced && p.UpdatedOn <= syncingTime);
               productDetailsEntries = GetProductDetailsEntries(productsToBeUpdated);               
            }

            try
            {
                using (var qRepo = new ProductDetailsRepository(queryContext))
                {
                    qRepo.AddRange(productDetailsEntries);
                    qRepo.Save();
                }
            }
            catch (Exception)
            {
                return;
            }

            LastSynced = syncingTime;
        }

        private IEnumerable<ProductDetails> GetProductDetailsEntries(IEnumerable<Product> products)
        {
            return products.Select(product => new ProductDetails
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                ImagePath = product.ImagePaths,
                NumberOfUnits = product.NumberOfUnits,
//                Price = product.Price.UnitPrice,
                PostedUserId = product.ApplicationUserId,
                PostedUserName = product.ApplicationUser.UserName,
                CreatedBy = product.CreatedBy,
                CreatedOn = product.CreatedOn,
                UpdatedBy = product.UpdatedBy,
                Tags = string.Join(",", product.Tags.Select(t => t.Name)),
                Properties =
                    string.Join(Constants.ObjectSeperator,
                        product.Properties.Select(p => string.Format("{0}{1}{2}", p.Name, Constants.ItemSeperator, p.Value))),
                Status = product.Status,
                UpdatedOn = DateTime.Now
            });
        }
    }
}
