using DataAccess.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CartService
{
    class CartServiceUtil
    {
        ChartMapper chartMapper = new ChartMapper();

        public Response GetMyCart(int thisUserId, int from = 0, int to = 100, int reserve = 1)
        {
            Response response = new Response();

            ArrayList resultList = chartMapper.GetMyCart(thisUserId, from, to - from, reserve);

            response.status = "200";
            response.result = resultList;

            Console.WriteLine("1");

            return response;
        }

        public Response AddToCart(int thisUserId, int GameId, int ConsoleId)
        {
            Response response = new Response();

            try
            {
                chartMapper.AddToCart(thisUserId, GameId, ConsoleId);
                response.status = "200";
                response.error = "添加到购物车成功";
            }
            catch (Exception e)
            {
                response.status = "403";
                response.error = "SQL Error";
            }

            return response;
        }

        public Response RemoveFromCart(int thisUserId, int GameId)
        {
            Response response = new Response();

            try
            {
                chartMapper.DeleteByPrimaryKey(GameId, thisUserId);
                response.status = "200";
                response.error = "已从购物车中移除";
            }
            catch (Exception e)
            {
                response.status = "403";
                response.error = "SQL Error";
            }

            return response;
        }
    }
}
