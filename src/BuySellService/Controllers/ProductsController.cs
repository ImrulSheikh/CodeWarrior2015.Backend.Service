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
using EShopper.Helpers;
using EShopper.Models;
using DalBase = CW.Backend.DAL.Base;

namespace EShopper.Controllers {
    [AllowAnonymous]
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _repository;
        private readonly IProductCommentRepository _commentRepository;
        private readonly IProductPropertyRepository _propertyRepository;
        private ProductCRUDContext _context;
        public ProductsController() {
            _context = new ProductCRUDContext();
            if (_repository == null) _repository = new ProductRepository(_context);
            if (_commentRepository == null) _commentRepository = new ProductCommentRepository(_context);
            if (_propertyRepository == null) _propertyRepository = new ProductPropertyRepository(_context);
            if (_userRepository == null) _userRepository = new UserRepository(_context);
        }

        [Route("GetByCategory")]
        public HttpResponseMessage GetByCategory(int categoryId) {
            var products = _repository.GetAll().Where(p => p.CategoryId == categoryId).ToList();
            var productViews = products.Select(ConvertToProductSummary);

            var response = Request.CreateResponse(productViews);
            return response;
        }

        private ProductSummaryViewModel ConvertToProductSummary(Product p) {
            return new ProductSummaryViewModel {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                NumberOfUnits = p.NumberOfUnits,
                Discount = p.Discount,
                DiscountValidity = p.DiscountValidity,
                UnitPrice = p.UnitPrice,
                ImagePaths = ImagePathHelpers.GetSeverRelativeImagePaths(p.ImagePaths),
                PostedById = p.ApplicationUserId,
                PostedUserName = p.ApplicationUser.UserName,
                Properties = GetProductProperties(p.Id).ToDictionary(pp => pp.Name, pp => pp.Value),
                Rating = GetRating(p.ApplicationUserId),
                Location = p.ApplicationUser.Address,
            };
        }

        private ProductSummaryViewModel ConvertToProductDetails(Product p) {
            return new ProductDetailsViewModel(){
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                NumberOfUnits = p.NumberOfUnits,
                Discount = p.Discount,
                DiscountValidity = p.DiscountValidity,
                UnitPrice = p.UnitPrice,
                ImagePaths = ImagePathHelpers.GetSeverRelativeImagePaths(p.ImagePaths),
                PostedById = p.ApplicationUserId,
                PostedUserName = p.ApplicationUser.UserName,
                Properties = GetProductProperties(p.Id).ToDictionary(pp => pp.Name, pp => pp.Value),
                Rating = GetRating(p.ApplicationUserId),
                Location = p.ApplicationUser.Address,
                ProductComments = GetProductComments(p.Id)
            };
        }

        /*
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
        
         * [Route("GetAll")]
                public HttpResponseMessage GetAll() 
                {
            
                    var data = _repository.GetAll().ToList();
                    var viewData = data.Select(d => new ProductSummaryViewModel
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
        */
        [Route("Get/{productId}")]
        public HttpResponseMessage GetById(int productId) {
            var product = _repository.GetById(productId);
            var productView = ConvertToProductSummary(product);

            var response = Request.CreateResponse(productView);
            return response;
        }

        [Route("GetDetails/{productId}")]
        public HttpResponseMessage GetDetailsById(int productId) {
            var product = _repository.GetById(productId);
            var productView = ConvertToProductDetails(product);

            var response = Request.CreateResponse(productView);
            return response;
        }

        [Route("GetProductReviews")]
        public HttpResponseMessage GetProductReviews(int productId) {
            var response = Request.CreateResponse(GetProductComments(productId));

            return response;
        }

        [Route("GetRecommended")]
        public HttpResponseMessage GetRecommended()
        {
            var products = _repository.GetAll().Skip(4).Take(5).ToList();
            var response = Request.CreateResponse(products);

            return response;
        }

        private double GetRating(string userId) {
            return _userRepository.GetUserRating(userId);
        }

        private List<ProductProperty> GetProductProperties(int productId) {
            return _propertyRepository.GetAll().Where(pp => pp.ProductId == productId).ToList();
        }

        private List<ProductCommentViewModel> GetProductComments(int productId) {
            var comments = _commentRepository.GetAll().Where(c => c.ProductId == productId).ToList();
            var commentViews = comments.Select(d => new ProductCommentViewModel {
                Id = d.Id,
                Comment = d.Comment,
                HelpfulHits = d.HelpfulHits,
                StarRating = d.StarRating
            }).ToList();
            return commentViews;
        }


        //        [HttpPost]
        //        [Route("AddProduct")]
        //        public HttpResponseMessage Add(Product item)
        //        {
        //
        //            _repository.Add(item);
        //            _repository.Save();
        //
        //            var messages = new List<string>();
        //            messages.Add(item.GetType().ToString() + " added");
        //
        //            return Request.CreateResponse(HttpStatusCode.OK, messages);
        //        }
    }


}
