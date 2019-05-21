using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CardMatch
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ImagesApiController : ApiController
    {
        private ImagesLogic imagelogic = new ImagesLogic();

        [HttpGet]
        [Route("images")]
        public HttpResponseMessage GetAllImages()
        {
            try
            {
                List<ImageModel> images = imagelogic.GetAllImages();
                return Request.CreateResponse(HttpStatusCode.OK, images);//the request belongs to the controller

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);//release controller resources. The system creates an object of ProductsApiController, when running the project.
            imagelogic.Dispose();//release our resources.
        }
    }
}
