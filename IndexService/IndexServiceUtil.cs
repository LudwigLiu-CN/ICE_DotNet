using DataAccess.Controllers;
using DataAccessAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IndexService
{
    class IndexServiceUtil
    {
        private static ArrayList gameList = new ArrayList();
        private static int askTimes = 0;

        GamesMapper gamesMapper = new GamesMapper();
        
        /*Unfinished File path access*/
        public Response GetGames(bool reset)
        {
            Response response = new Response();
            if (reset)
            {
                gameList = gamesMapper.GetAll();
            }

            ArrayList result = new ArrayList();
            for(int i = askTimes * 12; i < (askTimes + 1) * 12; i++)
            {
                if (i > gameList.Count)
                {
                    break;
                }

                GameInfo gameInfo = GameInfo.convertToGameInfo((Games)gameList[i]);
                /*
                 get cover path
                 */
                result.Add(gameInfo);
            }

            response.status = "200";
            response.result = result;
            askTimes++;

            return response;
        }

        public Response SortGames(int flag)
        {
            askTimes = 0;
            Response response = new Response();
            if (flag == 1)
            {
                response = GetGames(false);
                return response;
            }

            gameList = 
        }
    }
}
