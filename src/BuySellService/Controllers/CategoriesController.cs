using System.Collections.Generic;
using BuySell.EntityModels;
using BuySell.GenericRepository;
using System.Net.Http;
using System.Web.Http;
using CodeWarrior2015.Backend.Service.ProductCRUD;

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
