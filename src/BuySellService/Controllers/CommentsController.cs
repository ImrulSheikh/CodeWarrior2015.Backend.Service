using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EShopper.Models;

namespace EShopper.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Comments")]
    public class CommentsController : ApiController
    {
        [Route("Get")]
        public HttpResponseMessage GetAll(string product) {
            
            var data = new List<ProductCommentViewModel>();

           data.Add(new ProductCommentViewModel()
           {
               Id = 3,
               Comment = "It's simple comment 1",
               HelpfulHits = 1,
               StarRating = 2
           });
           data.Add(new ProductCommentViewModel() {
               Id = 3,
               Comment = "It's simple comment 2",
               HelpfulHits = 100,
               StarRating = 3
           });

            var response = Request.CreateResponse(data);

            return response;

        }
    }
}
