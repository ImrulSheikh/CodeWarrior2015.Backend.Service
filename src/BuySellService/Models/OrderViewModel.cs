using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopper.Models {
    public class OrderViewModel {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public string OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public List<ProductSummaryViewModel> Products { get; set; }

        public OrderViewModel() {
            Products = new List<ProductSummaryViewModel>();
        }
    }

    public class DeliverOrderViewModel {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public List<ProductSummaryViewModel> Products { get; set; }
    }

}