using DataAccessAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CartService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResponseClass;

namespace ICEServer.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class CartController : ControllerBase
    {
        CartServiceUtil cartServiceUtil = new CartServiceUtil();

        [Route("/getMyCart")]
        [HttpGet]
        public Response getMyCart(int from = 0, int to = 0, int reverse = 1)
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

            response = cartServiceUtil.GetMyCart((int)id, from, to, reverse);

            return response;
        }

        [Route("/addToCart")]
        [HttpGet]
        public Response addToCart(int gameId, int consoleId)
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

            response = cartServiceUtil.AddToCart((int)id, gameId, consoleId);

            return response;
        }

        [Route("/removeFromCart")]
        [HttpGet]
        public Response removeFromCart(int gameId)
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

            response = cartServiceUtil.RemoveFromCart((int)id, gameId);

            return response;
        }
    }
}
