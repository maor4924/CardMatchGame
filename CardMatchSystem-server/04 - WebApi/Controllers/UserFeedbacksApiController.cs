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

    public class UserFeedbacksApiController : ApiController
    {
        private UserFeedbacksLogic userfeedbacklogic = new UserFeedbacksLogic();

        [HttpGet]
        [Route("userfeedbacks")]
        public HttpResponseMessage GetAllFeedbacks()
        {
            try
            {
                List<UserFeedbackModel> userfeedback = userfeedbacklogic.GetAllFeedbacks();
                return Request.CreateResponse(HttpStatusCode.OK, userfeedback);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("userfeedbacks")]
        public HttpResponseMessage AddFeedback(UserFeedbackModel userfeedbackModel)
        {
            try
            {
                UserFeedbackModel userFeedback = userfeedbacklogic.AddFeedback(userfeedbackModel);
                return Request.CreateResponse(HttpStatusCode.Created, userFeedback);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);//release controller resources. The system creates an object of ProductsApiController, when running the project.
            userfeedbacklogic.Dispose();//release our resources.
        }
    }
}
