using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResponseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishListSerive;

namespace ICEServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private IHttpContextAccessor _accessor;
        WishListServiceUtil wishListServiceUtil = new WishListServiceUtil();

        [Route("/checkInMyWishList")]
        [HttpGet]
        public Response checkInMyWishList(int gameId)
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

            response = wishListServiceUtil.CheckInMyWishList((int)id, gameId);

            return response;
        }

        [Route("/insertIntoWishList")]
        [HttpGet]
        public Response insertIntoWishList(int gameId)
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

            response = wishListServiceUtil.InsertIntoWishList((int)id, gameId);

            return response;
        }

        [Route("/removeFromWishList")]
        [HttpGet]
        public Response removeFromWishList(int gameId)
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

            response = wishListServiceUtil.RemoveFromWishList((int)id, gameId);

            return response;
        }

        [Route("/getMyWishList")]
        [HttpPost]
        public Response getMyWishList()
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

            response = wishListServiceUtil.GetMyWishList((int)id);

            return response;
        }
    }
}
