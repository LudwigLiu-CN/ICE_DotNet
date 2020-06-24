using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICE.Contexts;
using ICE.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private iceContext iceContext_ = new iceContext();

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET /getUser?id={id}
        [Route("/getUser")]
        [HttpGet]
        public string Get(int id)
        {
            Users target = iceContext_.Users.Find(id);
            return target.UserName;
        }

        // POST api/<testUserController>
        [HttpPost]
        public String Post(Users user, String name)
        {
            int id = user.UserId;
            Users target = iceContext_.Users.Find(id);
            target.UserName = name;
            iceContext_.Users.Update(target);
            iceContext_.SaveChanges();
            return target.UserName;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
