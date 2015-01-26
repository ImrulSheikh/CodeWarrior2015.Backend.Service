using System.Data.Entity;
using BuySell.EntityModels;
using EShopper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EShopper.Controllers
{
     [EnableCors("*", "*", "GET")]
    [Authorize]
    public class ProfilesController : ApiController
    {
        public ProfilesController()
        {

        }
        public HttpResponseMessage Get()
        {
            var data = new ProfileDbContext().Profiles;
            var response = Request.CreateResponse(data);

            return response;

        }
       
    }
}
