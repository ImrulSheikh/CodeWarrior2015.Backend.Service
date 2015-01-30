using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using CW.Backend.DAL.CRUD.Contexts;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories;
using CW.Backend.DAL.CRUD.Repositories.Interfaces;
using EShopper.Models;

namespace EShopper.Controllers
{
    [RoutePrefix("api/Wishlist")]
    public class WishlistController : ApiController
    {
        private IUserWishlistRepository _repository;
        private IProductRepository _productRepository;
        private ProductCRUDContext _context;
        public WishlistController()
        {
            var req = Request;
            _context = new ProductCRUDContext();
            _repository = new UserWishlistRepository(_context);
            _productRepository = new ProductRepository(_context);
        }

        [Route("GetCurrent")]
        public HttpResponseMessage GetCurrentWishlist()
        {
            var userName = Thread.CurrentPrincipal.Identity.Name;
            var data = _repository.GetByUserName(userName);
            data.Products = _productRepository.GetAll().Where(p => p.UserWishlistId == data.Id).ToList();
            var viewData = new WishlistViewModel(data);
            var response = Request.CreateResponse(viewData);

            return response;
        }

    }
}
