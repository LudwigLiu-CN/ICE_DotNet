using System;
using System.Collections.Generic;
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
            return indexServiceUtil.GetGames(reset);
        }

        [Route("/sortGames")]
        [HttpGet]
        public Response sortGames(int flag)
        {
            return indexServiceUtil.SortGames(flag);
        }

        [Route("/searchGamesByTitle")]
        [HttpGet]
        public Response searchGamesBytitle(String keyWords, bool reset)
        {
            return indexServiceUtil.SearchGamesByTitle(keyWords, reset);
        }

        [Route("/searchGamesByCate")]
        [HttpGet]
        public Response searchGamesByCate(int cateId, bool reset)
        {
            return indexServiceUtil.SearchGamesByCate(cateId, reset);
        }

        [Route("/searchGamesByConsole")]
        [HttpGet]
        public Response searchGamesByConsole(int consoleId, bool reset)
        {
            return indexServiceUtil.SearchGamesByConsole(consoleId, reset);
        }

        [Route("/searchGamesByPublisher")]
        [HttpGet]
        public Response searchGamesByPublihser(int publisherId, bool reset)
        {
            return indexServiceUtil.SearchGamesByPublisher(publisherId, reset);
        }
    }
}
