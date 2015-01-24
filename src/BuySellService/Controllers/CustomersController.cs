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
    [Authorize]
    public class CustomersController : ApiController
    {
        public CustomersController()
        {

        }

        public HttpResponseMessage Get()
        {
            var customers = new CustomerDbContext().Customers;
            var response = Request.CreateResponse(customers);

            return response;
           
        }

        public void Add(Customer customer)
        {
            var context = new CustomerDbContext();
            context.Add(customer);
            
        }

        //public HttpResponseMessage Get(string id)
        //{
        //    var customers = new MockCustomerDb().Customers.Where(x => x.Id == id);
        //    if (customers == null || customers.Count() == 0)
        //    {
        //        var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer not found");
        //       errorResponse.Headers.Add(Constants.AccessControlAllowOrigin, new[] { Constants.AllowedOrigin });

        //    }
        //    var response =  Request.CreateResponse(customers.First());
        //    response.Headers.Add(Constants.AccessControlAllowOrigin, new[] { Constants.AllowedOrigin });

        //    return response;
        //}
    }
}
