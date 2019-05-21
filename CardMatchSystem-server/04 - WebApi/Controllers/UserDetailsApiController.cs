using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CardMatch
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class UserDetailsApiController : ApiController
    {
        private UserDetailsLogic userdetailslogic = new UserDetailsLogic();

        [HttpGet]
        [Route("userdetails")]
        public HttpResponseMessage GetAllUserDetails()
        {
            try
            {
                List<UserDetailsModel> userdetail = userdetailslogic.GetAllUserDetails();
                return Request.CreateResponse(HttpStatusCode.OK, userdetail);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("userdetails/{username}")]
        public HttpResponseMessage GetUserID(string username)
        {
            try
            {
                UserDetailsModel userid = userdetailslogic.GetUserID(username);

                return Request.CreateResponse(HttpStatusCode.OK, userid);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("userdetails")]
        public HttpResponseMessage AddNewUser(UserDetailsModel userDetailModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    List<PropErrors> errorList = ErrorExtractor.ExtractError(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);//badrequest = 400
                }
                else
                {
                    UserDetailsModel userDetail = userdetailslogic.AddNewUser(userDetailModel);
                    return Request.CreateResponse(HttpStatusCode.Created, userDetail);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("userlogin")]
        public HttpResponseMessage Login(UserDetailsModel userDetailModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    List<PropErrors> errorList = ErrorExtractor.ExtractError(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);//badrequest = 400
                }
                else
                {
                    UserDetailsModel userDetail = userdetailslogic.Login(userDetailModel);
                    return Request.CreateResponse(HttpStatusCode.Created, userDetail);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);//release controller resources. The system creates an object of ProductsApiController, when running the project.
            userdetailslogic.Dispose();//release our resources.
        }
    }
}
