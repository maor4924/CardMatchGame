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

    public class ContactUsMessageApiController : ApiController
    {
        private ContactUsMessageLogic contactLogic = new ContactUsMessageLogic();

        [HttpPost]
        [Route("contactus")]
        public HttpResponseMessage AddMessage(ContactUsMessageModel contactUsMessageModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    List<PropErrors> errorList = ErrorExtractor.ExtractError(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);//badrequest = 400
                }
                ContactUsMessageModel contactUsMessage = contactLogic.AddMsg(contactUsMessageModel);
                return Request.CreateResponse(HttpStatusCode.Created, contactUsMessage);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);//release controller resources. The system creates an object of ProductsApiController, when running the project.
            contactLogic.Dispose();//release our resources.
        }
    }
}
