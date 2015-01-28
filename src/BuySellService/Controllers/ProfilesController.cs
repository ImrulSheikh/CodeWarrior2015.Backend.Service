using System.Data.Entity;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using BuySell.EntityModels;
using EShopper.DataContexts;
using EShopper.Models;
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
        public HttpResponseMessage Add(Profile customer)
        {
            var context = new ProfileDbContext();
            context.Add(customer);

            var messages = new List<string>();
            messages.Add("item added");
           
            return Request.CreateResponse(HttpStatusCode.OK, messages);
        }

        [HttpPost]
        [Route("AddImage")]
        public async Task<HttpResponseMessage> UploadImageAsync()
        {
            

            var messages = new List<string>();
            messages.Add("item added");
            if (Request.Content.IsMimeMultipartContent())
            {
                string uploadPath = HttpContext.Current.Server.MapPath("~/uploads");

                var streamProvider = new MyStreamProvider(uploadPath);

                await Request.Content.ReadAsMultipartAsync(streamProvider);


                foreach (var file in streamProvider.FileData)
                {
                    var fi = new FileInfo(file.LocalFileName);
                    messages.Add("File uploaded as " + fi.FullName + " (" + fi.Length + " bytes)");
                }

                return Request.CreateResponse(HttpStatusCode.OK, messages);
            }
            messages.Add("file not added");

            return Request.CreateResponse(HttpStatusCode.OK, messages);
        }
       
    }
}
