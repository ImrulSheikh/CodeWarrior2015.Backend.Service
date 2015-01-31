using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CW.Backend.DAL.CRUD.Entities;

namespace EShopper.Models {
    public class ProductCommentDetailsViewModel {
        public string Comment { get; set; }
        public int StarRating { get; set; }
        public int HelpfulHits { get; set; }

        public int ProductId { get; set; }

    }
}