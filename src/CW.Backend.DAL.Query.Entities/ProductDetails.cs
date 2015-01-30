using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CW.Backend.DAL.Base.Entities;

namespace CW.Backend.DAL.Query.Entities
{
    public class ProductDetails : BaseCoreEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfUnits { get; set; }
        public string ImagePath { get; set; }
        public string Tags { get; set; }
        public string Properties { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int PostedUserId { get; set; }
        public string PostedUserName { get; set; }
    }
}
