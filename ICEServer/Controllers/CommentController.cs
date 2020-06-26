using CommentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResponseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICEServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        CommentServiceUtil commentServiceUtil = new CommentServiceUtil();

        [Route("/addComment")]
        [HttpPost]
        public Response addComment(ReviewAdder r)
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

            response = commentServiceUtil.AddComment((int)id, r);

            return response;
        }

        //[Route("/allComment")]
        //[HttpPost]
        //public Response allComment(int gameId, int from = 0, int to, int reverse = 1)
        //{
        //    Response response = new Response();

        //    var httpContext = _accessor.HttpContext;
        //    SessionHelper session = new SessionHelper(httpContext);
        //    int userid = Convert.ToInt32(session.GetSession("id"));

        //    response = commentServiceUtil.
        //}

        [Route("/checkMyComment")]
        [HttpGet]
        public Response checkMyComment(int gameId)
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

            response = commentServiceUtil.CheckMyComment((int)id, gameId);

            return response;
        }

        [Route("/commentsNumber")]
        [HttpGet]
        public Response commentsNumber(int gameId)
        {
            Response response = new Response();

            response = commentServiceUtil.CommentsNumber(gameId);

            return response;
        }
    }
}
