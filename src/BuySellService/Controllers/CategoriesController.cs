using System.Collections.Generic;

using System.Net.Http;
using System.Web.Http;
using CW.Backend.DAL.CRUD.Entities;

namespace CW.Backend.Services.Controllers
{
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        //private ICategoryRepository repository;
        public CategoriesController()
        {
            
        }

        [Route("GetAllCategory")]
        public HttpResponseMessage GetCategory()
        {
            var categories = new List<Category>();

            for (int i = 0; i < 10; i++)
            {
                var cat = new Category() {Description = "des_", Name = "Name" + i};
                categories.Add(cat);
            }
            //var data = repository.GetAll();

            var response = Request.CreateResponse(categories);

            return response;

        }

        
    }
}
