
using CW.Backend.DAL.Base.Repositories;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories;
using EShopper.DataContexts;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EShopper.Controllers
{
    [Authorize]
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        private ProductRepository repository;
        public ProductsController(IRepository<Product> repository )
        {
            if(repository == null)
                repository = new ProductRepository(new ProductCRUDContext());
        }
    
        [Route("GetAllProduct")]
        public HttpResponseMessage Get()
        {
            
            var data = repository.GetAll();

            var response = Request.CreateResponse(data);

            return response;

        }

        [Route("GetProductById")]
        public HttpResponseMessage GetById(string id)
        {
            var data = repository.GetById(int.Parse(id));

            var response = Request.CreateResponse(data);

            return response;

        }

        [HttpPost]
       [Route("AddProduct")]
        public HttpResponseMessage Add(Product item)
        {
           
            repository.Add(item);
            repository.Save();

            var messages = new List<string>();
            messages.Add(item.GetType().ToString()+" added");
           
            return Request.CreateResponse(HttpStatusCode.OK, messages);
        }
    }
}
