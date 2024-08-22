using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Text;

namespace aspnet_get_started.Controllers
{
    public class WebApiController : ApiController
    {

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/data")]
        public System.Web.Http.IHttpActionResult GetData()
        {
            return Ok("GET API call received successfully");
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/upload")]
        public System.Web.Http.IHttpActionResult UploadFile()
        {
            if (!System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                return BadRequest("No file uploaded...");
            }

            var file = System.Web.HttpContext.Current.Request.Files[0];

            if (file == null || file.ContentLength <= 0)
            {
                return BadRequest("No file uploaded or invalid file format...");
            }

            var filename = Path.GetFileName(file.FileName);

            byte[] imageBytes;
            using (var memoryStream = new MemoryStream())
            {
                file.InputStream.CopyTo(memoryStream);
                imageBytes = memoryStream.ToArray();
            }

            // process byte array of file data...

            return Ok("File upload successful");
        }
    }
}