using System.Data.Entity;
using BuySell.EntityModels;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PatientData.Controllers
{
    [EnableCors("*","*","GET")]
    [Authorize]
    public class CustomersController : ApiController
    {
        public CustomersController()
        {

        }
        //[AllowAnonymous]
        public List<Customer> Get()
        {
            return new MockCustomerDb().Customers;
        }


        //[AllowAnonymous]
        public HttpResponseMessage Get(string id)
        {
            var customers = new MockCustomerDb().Customers.Where(x => x.Id == id);
            if (customers == null || customers.Count() == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer not found");
            }
            return Request.CreateResponse(customers.First());
        }
    }
}
