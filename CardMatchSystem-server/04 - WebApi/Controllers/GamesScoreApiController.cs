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

    public class GamesScoreApiController : ApiController
    {
        private GamesScoreLogic gamescorelogic = new GamesScoreLogic();

        [HttpGet]
        [Route("gamescores")]
        public HttpResponseMessage GetAllScores()
        {
            try
            {
                List<GamesScoreModel> gameScores = gamescorelogic.GetAllScores();
                return Request.CreateResponse(HttpStatusCode.OK, gameScores);//the request belongs to the controller

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("gamescores")]
        public HttpResponseMessage AddGameScore(GamesScoreModel gameScoreModel)
        {
            try
            {
                GamesScoreModel gameScore = gamescorelogic.AddGameScore(gameScoreModel);
                return Request.CreateResponse(HttpStatusCode.Created, gameScore);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);//release controller resources.
            gamescorelogic.Dispose();//release our resources.
        }
    }
}


