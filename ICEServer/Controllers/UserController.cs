using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResponseClass;
using UserService;

namespace ICEServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IHttpContextAccessor _accessor;
        UserServiceUtil userServiceUtil = new UserServiceUtil();

        public UserController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        [Route("/login")]
        [HttpPost]
        public Response login(Users user)
        {
            Response response = new Response();
            int flag = userServiceUtil.Login(user);
            if(flag == -1)
            {
                response.status = "500";
                response.error = "Wrong Password!";
                return response;
            }
            else if(flag == -2)
            {
                response.status = "500";
                response.error = "Invalid User Name!";
                return response;
            }
            else
            {
                response.status = "200";
                response.error = "login";
                response.result.Add(flag);

                var httpContext = _accessor.HttpContext;
                SessionHelper session = new SessionHelper(httpContext);
                session.SetSession("id", flag.ToString());

                return response;
            }

        }

        [Route("/updateInfo")]
        [HttpPost]
        public Response updateInfo(Users user)
        {
            return userServiceUtil.UpdateInfo(user);
        }
    }
}
