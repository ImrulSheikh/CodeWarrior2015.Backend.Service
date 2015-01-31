using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using CW.Backend.DAL.CRUD.Contexts;
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

        [Route("GetAll")]
        public HttpResponseMessage GetAll() {
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
                    SubCategories = GenerateTree(categories.Where(cat => cat.ParentId != parentId).ToList(), c.Id)
                });

            return categoriesViewModel.ToList();
        }

        [Route("GetAttributes/{categoryId}")]
        public HttpResponseMessage GetAttributes(int categoryId) {
            var categoryPropertyRepository = new CategoryPropertyRepository();

            List<CategoryPropertyViewModel> propertiesViewModels;

            using (var context = new ProductCRUDContext())
            {
                propertiesViewModels = context.CategoryProperties
                    .Include("AvailableValues").Where(cp => cp.CategoryId.Equals(categoryId)).Select(cp=> new CategoryPropertyViewModel()
                    {
                        Id = cp.Id,
                        Name = cp.Name,
                        IsMandatory = cp.IsMandatory,
                        AvailableValues = cp.AvailableValues.Select(av=> av.Name).ToList()
                    }).ToList();
            }

            var response = Request.CreateResponse(propertiesViewModels);
            return response;
        }

        [Route("GetSubCategories/{categoryId}")]
        public HttpResponseMessage GetSubCategories(int categoryId)
        {
            List<CategoryViewModel> categoriesViewModel;

            using (var context = new ProductCRUDContext())
            {
                using (var repo = new CategoryRepositoy(context))
                {
                    var ctgr = repo.GetAllIncluding(ct => ct.SubCategories).First(ct => ct.Id == categoryId);
                    categoriesViewModel = ctgr.SubCategories.Select(ct => new CategoryViewModel
                    {
                        Id = ct.Id,
                        Name = ct.Name,
                        Description = ct.Description
                    }).ToList();
                }
            }

            var response = Request.CreateResponse(categoriesViewModel);
            return response;
        }


        private static List<string> GetAvailableList(CategoryProperty categoryProperty) {
            var availableList = new List<string>();

            if (categoryProperty.AvailableValues != null && categoryProperty.AvailableValues.Count > 0) {
                foreach (var cpAvailableValuese in categoryProperty.AvailableValues) {
                    if (!string.IsNullOrWhiteSpace(cpAvailableValuese.Name)) {
                        availableList.Add(cpAvailableValuese.Name);
                    }
                }
            }

            return availableList;
        }
    }
}
