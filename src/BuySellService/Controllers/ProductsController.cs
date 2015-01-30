using System;
using System.Collections.ObjectModel;
using System.Linq;
using CW.Backend.DAL.CRUD.Contexts;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CW.Backend.DAL.CRUD.Repositories.Interfaces;
using EShopper.Models;
using DalBase = CW.Backend.DAL.Base;

namespace EShopper.Controllers {
    [AllowAnonymous]
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController {
        private readonly IProductRepository _repository;
        private readonly IProductCommentRepository _commentRepository;
        private ProductCRUDContext _context;
        public ProductsController() {
            _context = new ProductCRUDContext();
            if (_repository == null)
                _repository = new ProductRepository(_context);
            if(_commentRepository==null)
                _commentRepository = new ProductCommentRepository(_context);
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
        public HttpResponseMessage GetAll() 
        {
            
            var data = _repository.GetAll().ToList();
            var viewData = data.Select(d => new ProductViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                NumberOfUnits = d.NumberOfUnits,
                Discount = d.Discount,
                DiscountValidity = d.DiscountValidity,
                UnitPrice = d.UnitPrice,
                ImagePaths = d.ImagePaths
                    .Split(new[] {DalBase.Constants.ObjectSeperator}, StringSplitOptions.None)
                    .ToList(),
                PostedById = d.ApplicationUserId,
                PostedUserName = d.ApplicationUser.UserName
            });

            var response = Request.CreateResponse(viewData);

            return response;
        }

        [Route("GetAllWithSellersLocation")]
        public HttpResponseMessage GetAllWithSellersLocation()
        {

            var data = _repository.GetAll().ToList();
            var viewData = data.Select(d => new ProductViewSellerModel
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                NumberOfUnits = d.NumberOfUnits,
                Discount = d.Discount,
                DiscountValidity = d.DiscountValidity,
                UnitPrice = d.UnitPrice,
                ImagePaths = d.ImagePaths
                    .Split(new[] { DalBase.Constants.ObjectSeperator }, StringSplitOptions.None)
                    .ToList(),
                PostedById = d.ApplicationUserId,
                PostedUserName = d.ApplicationUser.UserName,
                Location = d.ApplicationUser.Address
            });

            var response = Request.CreateResponse(viewData);

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

        [Route("GetProductById")]
        public HttpResponseMessage GetById(string id) {
            
            var data = _repository.GetById(int.Parse(id));
            var viewData = new ProductViewModel
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description,
                NumberOfUnits = data.NumberOfUnits,
                Discount = data.Discount,
                DiscountValidity = data.DiscountValidity,
                UnitPrice = data.UnitPrice,
                ImagePaths = data.ImagePaths
                    .Split(new[] {DalBase.Constants.ObjectSeperator}, StringSplitOptions.None)
                    .ToList(),
                PostedById = data.ApplicationUserId,
                PostedUserName = data.ApplicationUser.UserName
            };

            var response = Request.CreateResponse(viewData);

            return response;

        }

        [Route("GetProductWithSeller")]
        public HttpResponseMessage GetWithSeller(string id)
        {

            var data = _repository.GetById(int.Parse(id));
            var viewData = new ProductViewSellerModel
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description,
                NumberOfUnits = data.NumberOfUnits,
                Discount = data.Discount,
                DiscountValidity = data.DiscountValidity,
                UnitPrice = data.UnitPrice,
                ImagePaths = data.ImagePaths
                    .Split(new[] {DalBase.Constants.ObjectSeperator}, StringSplitOptions.None)
                    .ToList(),
                PostedById = data.ApplicationUserId,
                PostedUserName = data.ApplicationUser.UserName,
                Location = data.ApplicationUser.Address
            };

            var response = Request.CreateResponse(viewData);

            return response;

        }
        
        [Route("GetProductReviews")]
        public HttpResponseMessage GetProductReviews(string id)
        {

            var productId = int.Parse(id);
            var data = _commentRepository.GetAll().Where(c => c.ProductId == productId).ToList();
            var viewData = data.Select(d => new ProductCommentViewModel
            {
                Id = d.Id,
                Comment = d.Comment,
                HelpfulHits = d.HelpfulHits,
                StarRating = d.StarRating
            });

            var response = Request.CreateResponse(viewData);

            return response;
        }


        [HttpPost]
        [Route("AddProduct")]
        public HttpResponseMessage Add(Product item) {

            _repository.Add(item);
            _repository.Save();

            var messages = new List<string>();
            messages.Add(item.GetType().ToString() + " added");

            return Request.CreateResponse(HttpStatusCode.OK, messages);
        }
    }


}
