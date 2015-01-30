﻿using System;
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

namespace EShopper.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        private readonly IProductRepository _repository;
        private readonly IProductCommentRepository _commentRepository;
        private readonly IProductPropertyRepository _propertyRepository;
        private ProductCRUDContext _context;
        public ProductsController()
        {
            _context = new ProductCRUDContext();
            if (_repository == null) _repository = new ProductRepository(_context);
            if (_commentRepository == null) _commentRepository = new ProductCommentRepository(_context);
            if (_propertyRepository == null) _propertyRepository = new ProductPropertyRepository(_context);
        }

        [Route("GetByCategory")]
        public HttpResponseMessage GetByCategory(int categoryId)
        {
            var products = _repository.GetAll().Where(p => p.CategoryId == categoryId).ToList();
            var productViews = products.Select(p => new ProductViewModel
            {
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
                Rating = GetRatingFromComments(p.Id)
            });

            var response = Request.CreateResponse(productViews);

            return response;

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
        */
        [Route("Get/{productId}")]
        public HttpResponseMessage GetById(int productId)
        {
            var product = _repository.GetById(productId);
            var productView = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                NumberOfUnits = product.NumberOfUnits,
                Discount = product.Discount,
                DiscountValidity = product.DiscountValidity,
                UnitPrice = product.UnitPrice,
                Rating = GetRatingFromComments(productId),
                ImagePaths = ImagePathHelpers.GetSeverRelativeImagePaths(product.ImagePaths),
                PostedById = product.ApplicationUserId,
                PostedUserName = product.ApplicationUser.UserName,
                Properties = GetProductProperties(productId).ToDictionary(pp => pp.Name, pp => pp.Value)
            };

            var response = Request.CreateResponse(productView);

            return response;

        }


        [Route("GetProductWithSeller")]
        public HttpResponseMessage GetWithSeller(int productId)
        {
            var product = _repository.GetById(productId);
            var productSellerView = new ProductViewSellerModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                NumberOfUnits = product.NumberOfUnits,
                Discount = product.Discount,
                DiscountValidity = product.DiscountValidity,
                UnitPrice = product.UnitPrice,
                ImagePaths = ImagePathHelpers.GetSeverRelativeImagePaths(product.ImagePaths),
                PostedById = product.ApplicationUserId,
                PostedUserName = product.ApplicationUser.UserName,
                Location = product.ApplicationUser.Address,
                Properties = GetProductProperties(productId).ToDictionary(pp => pp.Name, pp => pp.Value),
                Rating = GetRatingFromComments(productId)
            };

            var response = Request.CreateResponse(productSellerView);

            return response;

        }

        [Route("GetProductReviews")]
        public HttpResponseMessage GetProductReviews(int productId)
        {
            var comments = GetProductComments(productId);
            var commentViews = comments.Select(d => new ProductCommentViewModel
            {
                Id = d.Id,
                Comment = d.Comment,
                HelpfulHits = d.HelpfulHits,
                StarRating = d.StarRating
            });

            var response = Request.CreateResponse(commentViews);

            return response;
        }

        private double GetRatingFromComments(int productId)
        {
            var comments = GetProductComments(productId);
            return comments.Count == 0 ? 0 : comments.Average(c => c.StarRating);
        }

        private List<ProductProperty> GetProductProperties(int productId)
        {
            return _propertyRepository.GetAll().Where(pp => pp.ProductId == productId).ToList();
        }

        private List<ProductComment> GetProductComments(int productId)
        {
            return _commentRepository.GetAll().Where(c => c.ProductId == productId).ToList();
        }


        [HttpPost]
        [Route("AddProduct")]
        public HttpResponseMessage Add(Product item)
        {

            _repository.Add(item);
            _repository.Save();

            var messages = new List<string>();
            messages.Add(item.GetType().ToString() + " added");

            return Request.CreateResponse(HttpStatusCode.OK, messages);
        }
    }


}
