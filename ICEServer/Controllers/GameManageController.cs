using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameManageService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResponseClass;

namespace ICEServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameManageController : ControllerBase
    {
        GameManageServiceUtil gameManageService = new GameManageServiceUtil();

        [Route("/getAllTags")]
        [HttpGet]
        public Response getAllTags()
        {
            Response response = gameManageService.getAllTags();
            return response;
        }

        [Route("/initGamelist")]
        [HttpGet]
        public Response initGamelist(int pageSize)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null||id<0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            else
            {
                Response response = gameManageService.initGameList(pageSize, id.Value);
                return response;
            }
        }

        [Route("/searchPublishedGames")]
        [HttpGet]
        public Response searchPublishedGames(String query,int currentPage,int pageSize)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null || id < 0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            else
            {
                Response response = gameManageService.searchPublishedGames(query,currentPage,pageSize, id.Value);
                return response;
            }
        }

        [Route("/jumpToGamePage")]
        [HttpGet]
        public Response jumpToGamePage(int targetPage, int pageSize)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null || id < 0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            else
            {
                Response response = gameManageService.jumpToGamePage(targetPage, pageSize, id.Value);
                return response;
            }
        }

        [Route("/addGame")]
        [HttpPost]
        public Response addGame(GameAdder gameAdder)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null || id < 0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            else
            {
                Response response = gameManageService.addGame(gameAdder, id.Value);

                return response;
            }
        }

        [Route("/postImg")]
        [HttpPost]
        public Response postImg(IFormCollection files,String type,int game_id)
        {
            Response response = new Response();

            int? id = HttpContext.Session.GetInt32("id");
            if (id == null || id < 0)
            {
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            else
            {
                int i = 0;
                foreach(var f in files.Files)
                {
                    i += 1;
                    string[] strs = f.FileName.Split('.');
                    string path;
                    if(type == "cover")
                    {
                        path = "Img/Games/" + game_id + "/" +  type + "." + strs[strs.Length - 1];

                    }
                    else
                    {
                        path = "Img/Games/" + game_id + "/" + i + "." + strs[strs.Length - 1];

                    }
                    f.CopyTo(new FileStream(path, FileMode.Create));
                    response.status = "200";
                    //response.error = "Upload success !";
                }
                
                return response;
            }
        }

        [Route("/deleteGame")]
        [HttpDelete]
        public Response deleteGame(int gameId)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null || id < 0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            else
            {
                Response response = gameManageService.deleteGame(gameId, id.Value);
                return response;
            }
        }

        [Route("/modifyGame")]
        [HttpPost]
        public Response modifyGame(GameModifier gameModifier)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null || id < 0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            else
            {
                Response response = gameManageService.modifyGame(gameModifier, id.Value);
                return response;
            }
        }

    }
}