using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using CW.Backend.DAL.CRUD.Contexts;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories;
using EShopper.Models;

namespace CW.Backend.Services.Controllers
{

    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        private CategoryRepositoy repository;
        private ProductCRUDContext crudContext;
        public CategoriesController()
        {
            crudContext = new ProductCRUDContext();
            repository = new CategoryRepositoy();
        }

        [Route("GetAllCategory")]
        public HttpResponseMessage GetCategory()
        {
/*
            var categorieList = repository.GetAll();

            var categories = new List<Category>();

            var category = new Category() {Id= 0, Description = "Electronics", Name = "Electronics" };
            category.SubCategories = new Collection<Category>();

            var subCategory = new Category() { Id = 100, ParentId = 0, Name = "Laptop" };
            category.SubCategories.Add(subCategory);

            subCategory = new Category() { Id = 101, ParentId = 0, Name = "Mobile" };
            category.SubCategories.Add(subCategory);
            
            subCategory = new Category() { Id = 102, ParentId = 0, Name = "Home Applicance" };
            category.SubCategories.Add(subCategory);

            categories.Add(category);

            category = new Category() { Id = 1, Description = "Vehicle", Name = "Vehicle" };
            category.SubCategories = new Collection<Category>();

            subCategory = new Category() { Id = 110, ParentId = 1, Name = "Toyota" };
            category.SubCategories.Add(subCategory);

            categories.Add(category);
            //var data = repository.GetAll();
*/
            using (var catRepo = new CategoryRepositoy(crudContext))
            {
                var categories = catRepo.GetAll().Select(c=>new CategoryViewModel(c));
                var response = Request.CreateResponse(categories);

                return response;
            }
        }

        
    }
}
