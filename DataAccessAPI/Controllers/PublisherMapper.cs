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
    public class PublisherMapper : ControllerBase
    {
        private iceContext _context = new iceContext();

        [Route("/PublisherMapper/SelectByPrimaryKey")]
        [HttpGet]
        public Publishers SelectByPrimaryKey(int publisherId)
        {
            Publishers p = _context.Publishers.Find(publisherId);
            return p;
        }

        public void UpdateByPrimaryKeySelective(Publishers record)
        {
            Publishers p = _context.Publishers.Find(record.PublisherId);

            if (record.PublisherName != null)
            {
                p.PublisherName = record.PublisherName;
            }

            if (record.LogoPath != null)
            {
                p.PublisherName = record.PublisherName;
            }

            if (record.Pwd != null)
            {
                p.Pwd = record.Pwd;
            }

            if (record.Description != null)
            {
                p.Description = record.Description;
            }
            _context.Publishers.Update(p);
            _context.SaveChanges();

        }

        public List<Publishers> SelectAll()
        {
            var targets = from p in _context.Publishers select p;
            List<Publishers> result = new List<Publishers>();
            foreach(var t in targets)
            {
                result.Add(t);
            }
            return result;

        }

        public List<Publishers> SelectByName(String publisherName)
        {
            var targets = from p in _context.Publishers where p.PublisherName==publisherName select p;
            List<Publishers> result = new List<Publishers>();
            foreach (var t in targets)
            {
                result.Add(t);
            }
            return result;

        }

    }
}
