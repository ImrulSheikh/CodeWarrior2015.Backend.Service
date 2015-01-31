using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CW.Backend.DAL.CRUD.Entities;

namespace EShopper.Models {
    public class SellerProfileViewModels {
        public UserProfileViewModel User { get; set; }
        public float Rating { get; set; }
        public List<ProductSummaryViewModel> Products { get; set; }
    }
}