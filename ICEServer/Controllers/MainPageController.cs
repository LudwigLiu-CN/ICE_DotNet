using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IndexService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResponseClass;

namespace ICEServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainPageController : ControllerBase
    {
        IndexServiceUtil indexServiceUtil = new IndexServiceUtil();

        [Route("/getGames")]
        [HttpGet]
        public Response getGames(bool reset)
        {
            return getAllCovers(indexServiceUtil.GetGames(reset));
        }

        [Route("/sortGames")]
        [HttpGet]
        public Response sortGames(int flag)
        {
            return getAllCovers(indexServiceUtil.SortGames(flag));
        }

        [Route("/searchGamesByTitle")]
        [HttpGet]
        public Response searchGamesBytitle(String keyWords, bool reset)
        {
            return getAllCovers(indexServiceUtil.SearchGamesByTitle(keyWords, reset));
        }

        [Route("/searchGamesByCate")]
        [HttpGet]
        public Response searchGamesByCate(int cateId, bool reset)
        {
            return getAllCovers(indexServiceUtil.SearchGamesByCate(cateId, reset));
        }

        [Route("/searchGamesByConsole")]
        [HttpGet]
        public Response searchGamesByConsole(int consoleId, bool reset)
        {
            return getAllCovers(indexServiceUtil.SearchGamesByConsole(consoleId, reset));
        }

        [Route("/searchGamesByPublisher")]
        [HttpGet]
        public Response searchGamesByPublihser(int publisherId, bool reset)
        {
            return getAllCovers(indexServiceUtil.SearchGamesByPublisher(publisherId, reset));
        }
   

        public Response getAllCovers(Response inputResponse)
        {
            Response response = new Response();

            ArrayList allGames = inputResponse.result;
            foreach(var gInfo in allGames)
            {
                GameInfo temp = (GameInfo)gInfo;
                DirectoryInfo TheFolder = new DirectoryInfo("./Img/Games/" + temp.id.ToString());
                if (TheFolder.Exists)
                {
                    foreach (FileInfo NextFile in TheFolder.GetFiles())
                    {
                        if (NextFile.Name.Substring(0, 5).Equals("cover"))
                        {
                            temp.cover_path = NextFile.FullName;
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
