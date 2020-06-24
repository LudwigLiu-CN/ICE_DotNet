using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessAPI.Contexts;
using DataAccessAPI.Models;
using System.Collections;

namespace DataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HasTagMapper : ControllerBase
    {
        private iceContext iceContext_ = new iceContext();

        [Route("/HasTagMapper/deleteByPrimaryKey")]
        [HttpGet]
        public void DeleteByPrimaryKey(int gameId, int tagId)
        {
            
            var t = iceContext_.HasTag.FirstOrDefault(m => m.GameId == gameId & m.TagId == tagId);
            if (t != null)
            {
                iceContext_.HasTag.Remove(t);
                iceContext_.SaveChanges();
            }
           
        }
        [Route("/HasTagMapper/Insert")]
        [HttpGet]
        public void Insert(HasTag update)
        {
            iceContext_.HasTag.Add(update);
            iceContext_.SaveChanges();
        }

        // 需要确定是否传入空值
        public void InsertSelective(HasTag update)
        {
            iceContext_.HasTag.Add(update);
            iceContext_.SaveChanges();
        }










        [Route("/HasTagMapper/selectByGameId")]
        [HttpGet]
        public ArrayList SelectByGameId(int gameId)
        {
            var targets = from t in iceContext_.HasTag where t.GameId == gameId select t;
            ArrayList results = new ArrayList();
            foreach(var t in targets)
            {
                results.Add(t);
            }
            return results;
        }
    }
}
