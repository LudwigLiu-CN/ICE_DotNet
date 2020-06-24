using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessAPI.Contexts;
using DataAccessAPI.Models;

namespace DataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayedOnsMapper : ControllerBase
    {
        private iceContext _context = new iceContext();

        [Route("/PlayedOnMapper/deleteByPrimaryKey")]
        [HttpGet]
        public void DeleteByPrimaryKey(int gameId, int consoleId)
        {
            PlayedOn t = _context.PlayedOn.Find(gameId, consoleId);
            _context.PlayedOn.Remove(t);
            _context.SaveChanges();
        }

        [Route("/PlayedOnMapper/Insert")]
        [HttpGet]
        public void Insert(PlayedOn p)
        {
            _context.PlayedOn.Add(p);
            _context.SaveChanges();
        }

        [Route("/PlayedOnMapper/SelectByConsoleId")]
        [HttpGet]
        public List<PlayedOn> SelectByConsoleId(int consoleId)
        {
            var targets = from p in _context.PlayedOn where p.ConsoleId == consoleId select p;
            List<PlayedOn> results = new List<PlayedOn>();
            foreach(var t in targets)
            {
                results.Add(t);
     
            }
            return results;
        }
        [Route("/PlayedOnMapper/SelectPrimaryKey")]
        [HttpGet]
        public PlayedOn SelectPrimaryKey(int gameId,int consoleId)
        {
            var p = _context.PlayedOn.Find(gameId, consoleId);
            return p;
        }

        [Route("/PlayedOnMapper/SelectByGameId")]
        [HttpGet]
        public List<PlayedOn> SelectByGameId(int gameId)
        {
            var targets = from p in _context.PlayedOn where p.GameId == gameId select p;
            List<PlayedOn> results = new List<PlayedOn>();
            foreach (var t in targets)
            {
                results.Add(t);

            }
            return results;
        }


        [Route("/PlayedOnMapper/DeleteByGameId")]
        [HttpGet]
        public void DeleteByGameId(int gameId)
        {
            var targets = from p in _context.PlayedOn where p.GameId == gameId select p;
            foreach(var t in targets)
            {
                _context.PlayedOn.Remove(t);

            }
            _context.SaveChanges();


        }






    }
}
