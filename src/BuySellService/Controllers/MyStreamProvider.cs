using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EShopper.Controllers
{
    public class MyStreamProvider : MultipartFormDataStreamProvider
    {
        public MyStreamProvider(string uploadPath)
            : base(uploadPath)
        {

        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            string fileName = Guid.NewGuid().ToString() + "_" + headers.ContentDisposition.FileName;
            return fileName.Replace("\"", string.Empty);
        }
    }
}