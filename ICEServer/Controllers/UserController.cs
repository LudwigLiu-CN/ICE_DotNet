using System;
using System.Collections;
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

        [Route("/logout")]
        [HttpPost]
        public Response logout()
        {
            var httpContext = _accessor.HttpContext;
            SessionHelper session = new SessionHelper(httpContext);
            session.SetSession("id", "-1");

            Response response = new Response();
            response.status = "200";
            return response;
        }

        [Route("/register")]
        [HttpPost]
        public Response register(Users user)
        {
            return userServiceUtil.Register(user);
        }

        [Route("/updateInfo")]
        [HttpPost]
        public Response updateInfo(Users user)
        {
            return userServiceUtil.UpdateInfo(user);
        }

        //updateAvatar

        [Route("/getAddress")]
        [HttpPost]
        public Response getAddress()
        {
            var httpContext = _accessor.HttpContext;
            SessionHelper session = new SessionHelper(httpContext);
            String idStr = session.GetSession("id");
            if(idStr == null)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            if(Convert.ToInt32(idStr) < 0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            return userServiceUtil.getAddress(Convert.ToInt32(idStr));
        }

        [Route("/updateAddress")]
        [HttpPost]
        public Response updateAddress(ArrayList addresses)
        {
            var httpContext = _accessor.HttpContext;
            SessionHelper session = new SessionHelper(httpContext);
            String idStr = session.GetSession("id");
            if (idStr == null)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            if (Convert.ToInt32(idStr) < 0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            return userServiceUtil.UpdateAddress(addresses, Convert.ToInt32(idStr));
        }
    }
}
