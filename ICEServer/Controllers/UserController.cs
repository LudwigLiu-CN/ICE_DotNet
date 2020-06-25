using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        UserServiceUtil userServiceUtil = new UserServiceUtil();

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

                HttpContext.Session.SetInt32("id", flag);

                return response;
            }

        }

        [Route("/logout")]
        [HttpPost]
        public Response logout()
        {
            HttpContext.Session.SetInt32("id", -1);

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
            int? id = HttpContext.Session.GetInt32("id");
            if(id == null)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            if(id < 0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            return userServiceUtil.getAddress(id.Value);
        }

        [Route("/updateAddress")]
        [HttpPost]
        public Response updateAddress(ArrayList addresses)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            if (id < 0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            return userServiceUtil.UpdateAddress(addresses, id.Value);
        }
    }
}
