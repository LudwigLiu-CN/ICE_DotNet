using DataAccess.Controllers;
using DataAccessAPI.Models;
using ResponseClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WishListService;

namespace WishListSerive
{
    public class WishListServiceUtil
    {
        WishlishMapper wishlishMapper = new WishlishMapper();
        GamesMapper gamesMapper = new GamesMapper();

        public Response CheckInMyWishList(int thisUserId, int gameId)
        {
            Response response = new Response();

            try
            {
                Wishlist w = wishlishMapper.SelectByPrimaryKey(gameId, thisUserId);
                if (w != null)
                {
                    response.status = "200";
                    response.error = "Already in your wishlist";
                }
                else
                {
                    response.error = "Not yet in your wishlist";
                    response.status = "404";
                }
            }
            catch (Exception e)
            {
                response.error = "SQL Error";
                response.status = "403";
            }

            return response;
        }

        public Response InsertIntoWishList(int thisUserId, int gameId)
        {
            Response response = new Response();

            try
            {
                Wishlist record = new Wishlist();
                record.GameId = gameId;
                record.UserId = thisUserId;
                // 不知道这个有什么用，默认设置了true
                record.Notification = true;
                wishlishMapper.Insert(record);
                response.status = "200";
                response.error = "Game has been successfully added to your wishlist";
            }
            catch (Exception e)
            {
                response.error = "SQL Error";
                response.status = "403";
            }
            return response;
        }

        public Response RemoveFromWishList(int thisUserId, int gameId)
        {
            Response response = new Response();

            try
            {
                wishlishMapper.DeleteByPrimaryKey(gameId, thisUserId);
                response.status = "200";
                response.error = "Game removed successfully";
            }
            catch (Exception e)
            {
                response.status = "403";
                response.error = "SQL Error";
            }
            return response;
        }

        public Response GetMyWishList(int thisUserId)
        {
            Response response = new Response();

            try
            {
                ArrayList l = wishlishMapper.SelectByUserId(thisUserId);
                ArrayList result = new ArrayList();

                if (l.Count == 0)
                {
                    response.status = "404";
                    response.error = "Your wishlist is now empty";
                    return response;
                }
                foreach(var wl in l)
                {
                    Wishlist temp = (Wishlist)wl;
                    GameInfo temp_info = GameInfo.convertToGameInfo(gamesMapper.SelectByPrimaryKey(temp.GameId));
                    result.Add(temp_info);
                }
                response.status = "200";
                response.result = result;
            }
            catch (Exception e)
            {
                response.error = "SQL Error";
                response.status = "403"; 
            }
            return response;
        }
    }
}
