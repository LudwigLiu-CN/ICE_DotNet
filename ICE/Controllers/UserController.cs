using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICE.Contexts;
using ICE.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private iceContext iceContext_ = new iceContext();


        // GET /getUser?id={id}
        [Route("/getUser")]
        [HttpGet]
        public string GetUserByID(int id)
        {
            Users target = iceContext_.Users.Find(id);
            return target.UserName;
        }

        // POST api/<testUserController>
        [Route("/TestChange")]
        [HttpPost]
        public String TestChangeUserName(Users user, String name)
        {
            int id = user.UserId;
            Users target = iceContext_.Users.Find(id);
            target.UserName = name;
            iceContext_.Users.Update(target);
            iceContext_.SaveChanges();
            return target.UserName;
        }
    }
}
