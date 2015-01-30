using System;
using System.Collections.Generic;
using System.Linq;
using CW.Backend.DAL.CRUD.Contexts;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories;
using CW.Backend.DAL.Query;
using CW.Backend.DAL.Query.Entities;
using CW.Backend.DAL.Query.Repositories;

namespace CW.Backend.Services.Synchronizer
{
    public class ProductSummarySynchronizer
    {
        private static DateTime LastSynced;
        public void Sync()
        {
            var syncingTime = DateTime.Now;
            var crudContext = new ProductCRUDContext();
            var queryContext = new ProductFlatContext();
            IEnumerable<ProductSummary> productSummaryEntries;

            using (var cRepo = new ProductRepository(crudContext))
            {
                var productsToBeUpdated =
                    cRepo.GetAll().Where(p => p.UpdatedOn >= LastSynced && p.UpdatedOn <= syncingTime);
               productSummaryEntries = GetProductSummaryEntries(productsToBeUpdated,syncingTime);               
            }

            try
            {
                using (var qRepo = new ProductSummaryRepository(queryContext))
                {
                    qRepo.AddRange(productSummaryEntries);
                    qRepo.Save();
                }
            }
            catch (Exception)
            {
                return;
            }

            LastSynced = syncingTime;
        }

        private IEnumerable<ProductSummary> GetProductSummaryEntries(IEnumerable<Product> products, DateTime syncingTime)
        {
            return products.Select(product => new ProductSummary
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                ImagePath = product.ImagePath,
                NumberOfUnits = product.NumberOfUnits,
//                Price = product.Price.UnitPrice,
                PostedUserId = product.PostedUserId,
                PostedUserName = product.PostedBy.UserName,
                CreatedBy = product.CreatedBy,
                CreatedOn = product.CreatedOn,
                UpdatedBy = product.UpdatedBy,
                Status = product.Status,
                UpdatedOn = syncingTime
            });
        }
    }
}
