using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopper.Models {
    public class OrderViewModel {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}