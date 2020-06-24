using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using DataAccessAPI.Contexts;
using DataAccessAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlishMapper : ControllerBase
    {
        iceContext iceContext_ = new iceContext();

        public Wishlist SelectByPrimaryKey(int GameId, int UserId)
        {
            Wishlist target = iceContext_.Wishlist.Find(GameId, UserId);
            return target;
        }

        public void DeleteByPrimaryKey(int GameId, int UserId)
        {
            Wishlist target = iceContext_.Wishlist.Find(GameId, UserId);
            iceContext_.Wishlist.Remove(target);
            iceContext_.SaveChanges();
        }

        public void Insert(Wishlist wishlist)
        {
            iceContext_.Wishlist.Add(wishlist);
            iceContext_.SaveChanges();
        }

        public void UpdateByPrimaryKey(Wishlist wishlist)
        {
            iceContext_.Wishlist.Update(wishlist);
            iceContext_.SaveChanges();
        }

        public ArrayList SelectByUserId(int userId)
        {
            var targets = from wl in iceContext_.Wishlist
                          where wl.UserId == userId
                          select wl;
            ArrayList results = new ArrayList();
            foreach(var wl in targets)
            {
                results.Add(wl);
            }

            return results;
        }

        public int selectCountByGameId(int gameId)
        {
            var targets = from wl in iceContext_.Wishlist
                          where wl.UserId == gameId
                          select wl;
            return targets.Count();
        }
    }
}
