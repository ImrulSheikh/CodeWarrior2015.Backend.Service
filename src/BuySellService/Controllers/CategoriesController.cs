using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories;
using EShopper.Models;

namespace EShopper.Controllers {

    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController {
        private CategoryRepositoy repository;
        public CategoriesController() {
            repository = new CategoryRepositoy();
        }

        [Route("GetAllCategory")]
        public HttpResponseMessage GetCategory() {
            var categories = GenerateTree(repository.GetAll().ToList(), 0);
            var response = Request.CreateResponse(categories);

            return response;

        }

        private List<CategoryViewModel> GenerateTree(List<Category> categories, int parentId) {
            var categoriesViewModel =
                categories.Where(cat => cat.ParentId.Equals(parentId)).Select(c => new CategoryViewModel() {
                    Id = c.Id,
                    Description = c.Description,
                    Name = c.Name,
                    SubCategories = GenerateTree(categories.Where(cat=> cat.ParentId != parentId).ToList(), c.Id)
                });

            return categoriesViewModel.ToList();
        }


    }
}
