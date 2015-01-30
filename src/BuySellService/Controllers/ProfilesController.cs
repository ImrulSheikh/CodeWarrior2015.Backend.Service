using System.Data.Entity;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using CW.Backend.DAL.CRUD.Entities;
using EShopper.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EShopper.Controllers
{
    [Authorize]
    [RoutePrefix("api/Profiles")]
    public class ProfilesController : ApiController
    {
        public ProfilesController()
        {
            var req = Request;
        }
    
        [Route("GetData")]
        public HttpResponseMessage Get()
        {
            var data = new ProfileDbContext().Profiles;
            var response = Request.CreateResponse(data);

            return response;

        }

        [HttpPost]
       [Route("AddData")]
        public HttpResponseMessage Add(Profile profile)
        {
            profile.UserName = HttpContext.Current.User.Identity.Name;
            profile.ProfileType = ProfileType.Seller.ToString();

            var context = new ProfileDbContext();
            context.Add(profile);

            var messages = new List<string>();
            messages.Add("profile added");
           
            return Request.CreateResponse(HttpStatusCode.OK, messages);
        }

        [HttpPost]
        [Route("AddImage")]
        public async Task<HttpResponseMessage> UploadImageAsync()
        {

            var userId = HttpContext.Current.User.Identity.Name;
            var context = new ProfileDbContext();
            var profile = context.Profiles.Where(x => x.UserName == userId && x.ProfileType == "Seller").First();

            



            var messages = new List<string>();
            if (Request.Content.IsMimeMultipartContent())
            {
                string uploadPath = HttpContext.Current.Server.MapPath("~/Content/uploads");

                var streamProvider = new MyStreamProvider(uploadPath);

                await Request.Content.ReadAsMultipartAsync(streamProvider);


                foreach (var file in streamProvider.FileData)
                {
                    var fi = new FileInfo(file.LocalFileName);
                    messages.Add("File uploaded as " + fi.FullName + " (" + fi.Length + " bytes)");
                }

                profile.ImagePath = uploadPath;
                context.SaveChanges();


                return Request.CreateResponse(HttpStatusCode.OK, messages);
            }
            messages.Add("file not added");

            return Request.CreateResponse(HttpStatusCode.OK, messages);
        }
       
    }
}
