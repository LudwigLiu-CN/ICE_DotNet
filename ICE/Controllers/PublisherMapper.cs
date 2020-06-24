using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ICE.Contexts;
using ICE.Models;

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


    }
}
