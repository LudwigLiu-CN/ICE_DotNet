using DataAccess.Controllers;
using DataAccessAPI.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace GameService
{
    class GameServiceUtil
    {
        GamesMapper gamesMapper = new GamesMapper();
        public Response GetGameDetail(int gameId)
        {
            Response response = new Response();
            Games target = gamesMapper.SelectByPrimaryKey(gameId);

            response.status = "200";
            response.result.Add(target);

            return response;
        }

        public Response getGameConsole(int gameId)
        {

        }
    }
}
