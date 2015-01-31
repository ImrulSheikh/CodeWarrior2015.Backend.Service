using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EShopper.Models;

namespace EShopper.Controllers
{
    [RoutePrefix("api/DeliverOrder")]
    public class DeliverOrderController : ApiController
    {
        [Route("GetOrder")]
        public HttpResponseMessage GetOrderByGroup()
        {
            var orders = new DeliverOrderViewModel();
//            orders.
            var response = Request.CreateResponse(orders);

            return response;

        }
    }
}
