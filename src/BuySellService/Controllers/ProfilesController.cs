using System.Data.Entity;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using CW.Backend.DAL.CRUD.Contexts;
using CW.Backend.DAL.CRUD.Entities;
using CW.Backend.DAL.CRUD.Repositories;
using CW.Backend.DAL.Query.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using EShopper.Helpers;
using EShopper.Models;

namespace EShopper.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Profiles")]
    public class ProfilesController : ApiController
    {
    
        [Route("GetBuyerProfile")]
        public HttpResponseMessage GetBuyerProfile(string userName = "") {
            using (var repo = new UserRepository()) {
                var user = repo.GetByUserName(userName);
                var orderRepo = new OrderRepository();
                var orders = orderRepo.GetAll().Where(o => o.ApplicationUserId.Equals(user.Id)).Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    DeliveryDate = o.DeliveryDate,
                    OrderDate = o.OrderDate,
                    Quantity = o.Quantity,
                    TotalPrice = o.TotalPrice
                });
                var response = Request.CreateResponse(orders);

                return response;
            }
        }

        [Route("GetSellerProfile/{userName}")]
        public HttpResponseMessage GetSellerProfile(string userName)
        {
            

            using (var context = new ProductCRUDContext())
            {
                var profile = new SellerProfileViewModels();

                var user = context.Users.Include("Products").FirstOrDefault(u => u.UserName.Equals(userName));

                if (user == null)
                {
                    throw new Exception("UserName is not valid !!");
                }
                //var user = new UserRepository().GetByUserName(userName);
                profile.User = new UserProfileViewModel() {
                    UserName = user.UserName,
                    FullName = user.FullName,
                    Address = user.Address,
                    Email = user.Email,
                    Sex = user.Sex,
                    PhoneNumber = user.PhoneNumber
                };
                profile.Rating = new UserRepository().GetUserRating(user.Id);
                profile.Products = user.Products.Select(ConvertToProductSummary).ToList();

                var response = Request.CreateResponse(profile);
                return response;
            }
            
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

        private double GetRating(string userId) {
            return new UserRepository().GetUserRating(userId);
        }

        private List<ProductProperty> GetProductProperties(int productId) {
            return new ProductPropertyRepository().GetAll().Where(pp => pp.ProductId == productId).ToList();
        }

//       [HttpPost]
//       [Route("AddData")]
//        public HttpResponseMessage Add(Profile profile)
//        {
//            profile.UserName = HttpContext.Current.User.Identity.Name;
//            profile.ProfileType = ProfileType.Seller.ToString();
//
//            var context = new ProfileDbContext();
//            context.Add(profile);
//
//            var messages = new List<string>();
//            messages.Add("profile added");
//           
//            return Request.CreateResponse(HttpStatusCode.OK, messages);
//        }
//
//        [HttpPost]
//        [Route("AddImage")]
//        public async Task<HttpResponseMessage> UploadImageAsync()
//        {
//
//            var userId = HttpContext.Current.User.Identity.Name;
//            var context = new ProfileDbContext();
//            var profile = context.Profiles.Where(x => x.UserName == userId && x.ProfileType == "Seller").First();
//
//            
//
//
//
//            var messages = new List<string>();
//            if (Request.Content.IsMimeMultipartContent())
//            {
//                string uploadPath = HttpContext.Current.Server.MapPath("~/Content/uploads");
//
//                var streamProvider = new MyStreamProvider(uploadPath);
//
//                await Request.Content.ReadAsMultipartAsync(streamProvider);
//
//
//                foreach (var file in streamProvider.FileData)
//                {
//                    var fi = new FileInfo(file.LocalFileName);
//                    messages.Add("File uploaded as " + fi.FullName + " (" + fi.Length + " bytes)");
//                }
//
//                profile.ImagePath = uploadPath;
//                context.SaveChanges();
//
//
//                return Request.CreateResponse(HttpStatusCode.OK, messages);
//            }
//            messages.Add("file not added");
//
//            return Request.CreateResponse(HttpStatusCode.OK, messages);
//        }
       
    }
}
