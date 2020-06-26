using CommentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResponseClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        
        [Route("/allComment")]
        [HttpPost]
        public Response allComment(int gameId, int to, int from = 0, int reverse = 1)
        {
            Response response = new Response();

            Response tempResponse = commentServiceUtil.AllComment(gameId, to, from, reverse);
            ArrayList comments = tempResponse.result;

            foreach(var cmt in comments)
            {
                ReviewWithUser tempReview = (ReviewWithUser)cmt;

                DirectoryInfo TheFolder = new DirectoryInfo("./Img/Users");
                if (TheFolder.Exists)
                {
                    foreach (FileInfo NextFile in TheFolder.GetFiles())
                    {
                        if (!NextFile.Name.Substring(0, 6).Equals(tempReview.userId.ToString()))
                        {
                            tempReview.avatarPath = "./Img/Users" + NextFile.Name;
                            break;
                        }
                    }
                }
                response.result.Add(tempReview);
            }
            response.status = "200";
            return response;
        }
        
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
