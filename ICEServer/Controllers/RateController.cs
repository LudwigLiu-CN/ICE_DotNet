using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateService;
using ResponseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICEServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private IHttpContextAccessor _accessor;
        RateServiceUtil rateServiceUtil = new RateServiceUtil();

        [Route("/submitRate")]
        [HttpGet]
        public Response submitRate(int gameId, int rate)
        {
            Response response = new Response();

            int? id = HttpContext.Session.GetInt32("id");
            if (id == null)
            {
                response.status = "500";
                response.error = "haven't logged in yet!";
                return response;
            }
            else if (id < 0)
            {
                response.status = "500";
                response.error = "haven't logged in yet!";
                return response;
            }

            response = rateServiceUtil.SubmitRate((int)id, gameId, rate);

            return response;
        }

        [Route("/getRate")]
        [HttpGet]
        public Response getRate(int gameId)
        {
            Response response = new Response();

            response = rateServiceUtil.GetRate(gameId);

            return response;
        }

        [Route("/getMyRate")]
        [HttpGet]
        public Response getMyRate(int gameId)
        {
            Response response = new Response();

            int? id = HttpContext.Session.GetInt32("id");
            if (id == null)
            {
                response.status = "500";
                response.error = "haven't logged in yet!";
                return response;
            }
            else if (id < 0)
            {
                response.status = "500";
                response.error = "haven't logged in yet!";
                return response;
            }

            response = rateServiceUtil.GetMyRate((int)id, gameId);

            return response;
        }
    }
}
