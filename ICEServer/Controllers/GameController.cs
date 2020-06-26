using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResponseClass;

namespace ICEServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        GameServiceUtil gameServiceUtil = new GameServiceUtil();

        [Route("/getGameDetail")]
        [HttpGet]
        public Response getGameDetail(int gameId)
        {
            return gameServiceUtil.GetGameDetail(gameId);
        }

        [Route("/getGameConsole")]
        [HttpGet]
        public Response getGameConsole(int gameId)
        {
            return gameServiceUtil.GetGameConsole(gameId);
        }

        [Route("/getGameTag")]
        [HttpGet]
        public Response getGameTag(int gameId)
        {
            return gameServiceUtil.GetGameTag(gameId);
        }

        [Route("/getGameCate")]
        [HttpGet]
        public Response getGameCate(int gameId)
        {
            return gameServiceUtil.GetGameCate(gameId);
        }

        [Route("/getGamePublisher")]
        [HttpGet]
        public Response getGamePublisher(int gameId)
        {
            return gameServiceUtil.GetGamePublisher(gameId);
        }

        [Route("/getPics")]
        [HttpGet]
        public Response getPics(int gameId)
        {
            Response response = new Response();

            ArrayList pics = new ArrayList();
            DirectoryInfo TheFolder = new DirectoryInfo("./wwwroot/Img/Games/"+gameId.ToString());
            if (TheFolder.Exists)
            {
                foreach (FileInfo NextFile in TheFolder.GetFiles())
                {
                    if (!NextFile.Name.Substring(0, 5).Equals("cover"))
                    {
                        response.result.Add("/Img/Games/" + gameId.ToString() + "/" + NextFile.Name);
                    }
                }
            }

            response.status = "200";
            return response;
        }
    }
}
