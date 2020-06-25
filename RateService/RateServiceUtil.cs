using DataAccess.Controllers;
using DataAccessAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RateService
{
    public class RateServiceUtil
    {
        RateGameMapper rateGameMapper = new RateGameMapper();
        GamesMapper gamesMapper = new GamesMapper();

        public Response SubmitRate(int thisUserId, int gameId, int rate)
        {
            Response response = new Response();

            try
            {
                rateGameMapper.SubmitRate(thisUserId, gameId, rate);

                Games game = gamesMapper.SelectByPrimaryKey(gameId);
                float rates = (float)((game.AverageRate * game.RateCount + rate) / (game.RateCount + 1));
                game.AverageRate = rates;
                game.RateCount = game.RateCount + 1;
                gamesMapper.UpdatePrimaryKeySelective(game);
                response.error = "Rating successfully submitted";
                response.status = "200";
            }
            catch (Exception e)
            {
                response.error = "SQL Error";
                response.status = "403";
            }
            return response;
        }

        public Response GetRate(int gameId)
        {
            Response response = new Response();

            try
            {
                double r = (double)gamesMapper.SelectByPrimaryKey(gameId).AverageRate;
                response.status = "200";
                response.error = Convert.ToString(r);
            }
            catch (Exception e)
            {
                response.error = "SQL Error";
                response.status = "403";
            }
            return response;
        }

        public Response GetMyRate(int thisUserId, int gameId)
        {
            Response response = new Response();

            try
            {
                int? r = rateGameMapper.MyRate(gameId, thisUserId);
                if (r == null)
                {
                    response.error = "You have not rated yet!!!";
                    response.status = "404";
                }
                else
                {
                    response.error = Convert.ToString(r);
                    response.status = "200";
                }
            }
            catch (Exception e)
            {
                response.error = "You have not rated yet";
                response.status = "404";
            }
            return response;
        }
    }
}
