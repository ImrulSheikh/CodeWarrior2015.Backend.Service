using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CW.Backend.DAL.CRUD.Entities;

namespace EShopper.Models
{
    public class ProductCommentDetailsViewModel : ProductCommentViewModel
    {
        public int ProductId { get; set; }
        public string ApplicationUserId { get; set; }

    }
}