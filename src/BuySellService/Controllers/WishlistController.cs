using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using CW.Backend.DAL.CRUD.Contexts;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories;
using CW.Backend.DAL.CRUD.Repositories.Interfaces;
using EShopper.Models;

namespace EShopper.Controllers {
    [RoutePrefix("api/Wishlist")]
    public class WishlistController : ApiController {
        private IUserWishlistRepository _repository;
        private IProductRepository _productRepository;
        private ProductCRUDContext _context;
        private IUserRepository _userRepository;

        public WishlistController() {
            var req = Request;
            _context = new ProductCRUDContext();
            _repository = new UserWishlistRepository(_context);
            _userRepository = new UserRepository(_context);
            _productRepository = new ProductRepository(_context);
        }

        [Authorize]
        [Route("Add")]
        public HttpResponseMessage AddToWishlist(int productId) {
            var userName = Thread.CurrentPrincipal.Identity.Name;
            var userData = _userRepository.GetByUserName(userName);
            string messages;

            if (_repository.GetAll().Any(w => w.WishedProductId == productId && w.WishedUserId == userData.Id))
                messages = "Already Added";
            else {
                _repository.Add(new UserWishlist { WishedProductId = productId, WishedUserId = userData.Id });
                //messages = userName + " added product id =" + productId + " to his/her wishlist";
                messages = "Item added to wishlist";
            }

            var response = Request.CreateResponse(messages);

            return response;
        }

        [Authorize]
        [Route("GetCurrent")]
        public HttpResponseMessage GetCurrentWishlist() {
            var userName = Thread.CurrentPrincipal.Identity.Name;
            var usrData = _userRepository.GetByUserName(userName);
            var wishedProdIds =
                _repository.GetAll()
                    .Where(w => w.WishedUserId == usrData.Id)
                    .Select(w => w.WishedProductId)
                    .Distinct()
                    .ToList();

            var wishedProds = from wishedProdId in wishedProdIds
                              join product in _productRepository.GetAll()
                                  on wishedProdId equals product.Id
                              select product;
            var viewData = ConvertToWishListView(usrData, wishedProds);

            var response = Request.CreateResponse(viewData);

            return response;
        }

        [HttpPost]
        [Authorize]
        [Route("Delete/{productId}")]
        public async Task<HttpResponseMessage> Delete(int productId) {
            var userName = Thread.CurrentPrincipal.Identity.Name;
            var usrData = _userRepository.GetByUserName(userName);
            var message = "Deletion was not successful !!";
            using (var context = new ProductCRUDContext()) {
                var wishlist =
                    await
                        context.UserWishlists.FirstOrDefaultAsync(
                            wl => wl.WishedUserId.Equals(usrData.Id) && wl.WishedProductId.Equals(productId));
                if (wishlist == null || wishlist.Id == 0) {
                    throw new Exception("This product is not in your wishlist");
                }
                context.UserWishlists.Remove(wishlist);
                await context.SaveChangesAsync();
                message = "Deletion was successful.";
            }

            var response = Request.CreateResponse(message);
            return response;
        }




        private WishlistViewModel ConvertToWishListView(ApplicationUser usrData, IEnumerable<Product> wishedProds) {
            return new WishlistViewModel {
                UserId = usrData.Id,
                UserName = usrData.UserName,
                Products = wishedProds.Select(product => new ProductSummaryViewModel {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Discount = product.Discount,
                    NumberOfUnits = product.NumberOfUnits,
                    DiscountValidity = product.DiscountValidity,
                    UnitPrice = product.UnitPrice,
                    ImagePaths = EShopper.Helpers.ImagePathHelpers.GetSeverRelativeImagePaths(product.ImagePaths)

                }).ToList()
            };
        }
    }
}
