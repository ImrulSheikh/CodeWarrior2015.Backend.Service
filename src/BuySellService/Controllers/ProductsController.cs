using System;
using System.Collections.ObjectModel;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories;
using EShopper.DataContexts;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EShopper.Models;

namespace EShopper.Controllers {
    [AllowAnonymous]
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController {
        private ProductRepository repository;
        public ProductsController() {
            if (repository == null)
                repository = new ProductRepository(new ProductCRUDContext());
        }

        [Route("GetAllProduct")]
        public HttpResponseMessage Get(string catId, string subCategoryId) {

            var data = new List<Product>();
            //
            //            var product = new Product() { Description = "Smart Phone Nokia", Name = "Lumia 925", Id = 0, UnitPrice = 11000 };
            //
            //            var serverPath = "http://localhost:64237//";
            //            product.ImagePaths = new Collection<string>();
            //            product.ImagePaths.Add(serverPath+"Content//uploads//mobile_smartPhone_1.JPG");
            //            product.ImagePaths.Add(serverPath+"Content//uploads//mobile_smartPhone_2.JPG");
            //            product.ImagePaths.Add(serverPath+"Content//uploads//mobile_smartPhone_3.PNG");
            //            data.Add(product);
            //
            //            product = new Product() { Description = "Smart Phone Samsung", Name = "Galaxy s5", Id = 1, UnitPrice = 61000 };
            //            product.ImagePaths = new Collection<string>();
            //            product.ImagePaths.Add(serverPath+"Content//uploads//mobile_smartPhone_3.PNG");
            //            data.Add(product);
            //
            //
            //            product = new Product() { Description = "Vehicle", Name = "Toyota", Id = 2, UnitPrice = 612000 };
            //            product.ImagePaths = new Collection<string>();
            //            product.ImagePaths.Add(serverPath+"Content//uploads//vehicle_car_1.png");
            //            data.Add(product);
            //            

            var response = Request.CreateResponse(data);

            return response;

        }

        [Route("GetAll")]
        public HttpResponseMessage GetAll() {
            var data = new List<ProductViewModel>();

            data.Add(new ProductViewModel()
            {
                Name = "LG G3",
                Description = "It's a smart phone",
                Discount = 10,
                DiscountValidity = DateTime.Now.AddDays(30),
                Id = 1,
                ImagePaths = new List<string>() { "aa","ab","cc" },
                NumberOfUnits = 20,
                UnitPrice = 50
            });

            data.Add(new ProductViewModel() {
                Name = "Samsung S6",
                Description = "It's a smart phone",
                Discount = 30,
                DiscountValidity = DateTime.Now.AddDays(20),
                Id = 1,
                ImagePaths = new List<string>() { "aa-s", "ab-e", "cc-e" },
                NumberOfUnits = 50,
                UnitPrice = 80
            });


            var response = Request.CreateResponse(data);

            return response;

        }

        [Route("Get/{product}")]
        public HttpResponseMessage Get(string product) {

            var response = Request.CreateResponse(new ProductViewModel() {
                Name = "LG G3",
                Description = "It's a smart phone",
                Discount = 10,
                DiscountValidity = DateTime.Now.AddDays(30),
                Id = 1,
                ImagePaths = new List<string>() { "aa", "ab", "cc" },
                NumberOfUnits = 20,
                UnitPrice = 50
            });

            return response;

        }
//
//        [Route("GetProductById")]
//        public HttpResponseMessage GetById(string id) {
//            var data = repository.GetById(int.Parse(id));
//
//            var response = Request.CreateResponse(data);
//
//            return response;
//
//        }
//
//        [HttpPost]
//        [Route("AddProduct")]
//        public HttpResponseMessage Add(Product item) {
//
//            repository.Add(item);
//            repository.Save();
//
//            var messages = new List<string>();
//            messages.Add(item.GetType().ToString() + " added");
//
//            return Request.CreateResponse(HttpStatusCode.OK, messages);
//        }
    }


}
