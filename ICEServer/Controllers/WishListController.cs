using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResponseClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WishListSerive;
using WishListService;

namespace ICEServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
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

            return getAllCovers(wishListServiceUtil.GetMyWishList(id.Value));
        }

        public Response getAllCovers(Response inputResponse)
        {
            Response response = new Response();

            ArrayList allGames = inputResponse.result;
            foreach (var gInfo in allGames)
            {
                GameInfo temp = (GameInfo)gInfo;
                DirectoryInfo TheFolder = new DirectoryInfo("./wwwroot/Img/Games/" + temp.id.ToString());
                if (TheFolder.Exists)
                {
                    foreach (FileInfo NextFile in TheFolder.GetFiles())
                    {
                        if (NextFile.Name.Substring(0, 5).Equals("cover"))
                        {
                            temp.cover_path = "/Img/Games/" + temp.id.ToString() + "/" + NextFile.Name;
                        }
                    }
                }

                response.result.Add(temp);
            }
            response.status = "200";
            return response;
        }
    }
}
